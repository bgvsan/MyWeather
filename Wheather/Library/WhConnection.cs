using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Wheather.ViewModels;
using System.Device.Location;
using Windows.Devices.Geolocation;


namespace Wheather.Library
{
    internal class WhConnection
    {

        public enum FormatType
        {
            Json,
            Html,
            Xml,
        }


        private const string _api_connection_string = "http://api.openweathermap.org/data/2.5/weather";
        private const string _api_connection_string_gps = "http://api.openweathermap.org/data/2.5/find";


        public HttpWebRequest webRequest;



        private string GetConnectionUrl(FormatType format,bool gps=false)
        {
            var connectionString = "";
            connectionString = gps ? _api_connection_string_gps : _api_connection_string; 
            switch (format)
            {
                case FormatType.Json:
                    connectionString += "?";
                    break;
                case FormatType.Xml:
                    connectionString += "?mode=xml";
                    break;
                case FormatType.Html:
                    connectionString += "?mode=html";
                    break;
            }

            return connectionString;
        }

        public void AbortRequest()
        {
            if (webRequest != null)
            {
                webRequest.Abort();
            }
        }

        public async Task<string> GetWheather(FormatType format, string city)
        {
            try
            {
                var connectionString = GetConnectionUrl(format) + "&q=" + city;
                var url = new Uri(connectionString);
                webRequest = (HttpWebRequest)WebRequest.Create(url);
                //block the method for the response.
               
                return await webRequest.GetResponseAsync().ContinueWith<String>(t =>
                {

                    var hwr = (HttpWebResponse)t.Result;
                    using (StreamReader reader = new StreamReader(hwr.GetResponseStream()))
                    {
                        string str = reader.ReadToEnd();
                        return str;
                    }
                }, TaskContinuationOptions.OnlyOnRanToCompletion);
            }

            catch (System.Threading.Tasks.TaskCanceledException TaskCancellation)
            {
                System.Diagnostics.Debug.WriteLine("errore http post" + TaskCancellation.ToString());
                throw new OperationCanceledException();
                //return "Task Cancellation";
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("errore http post" + ex.ToString());
                return "ERROR";
            }
        }

        public async Task<string> GetWheather(FormatType format, Geoposition pos, int cnt = 4)
        {
            
            try
            {
                var connectionString = GetConnectionUrl(format,true) + "&lat=" + pos.Coordinate.Latitude.ToString().Replace(",", ".") + "&lon=" + pos.Coordinate.Longitude.ToString().Replace(",", ".") + "&cnt=" + cnt;
        
                var url = new Uri(connectionString);
                var webRequest = (HttpWebRequest)WebRequest.Create(url);
                System.Diagnostics.Debug.WriteLine(url);
                //block the method for the response.

                return await webRequest.GetResponseAsync().ContinueWith<String>(t =>
                {

                    var hwr = (HttpWebResponse)t.Result;
                    using (StreamReader reader = new StreamReader(hwr.GetResponseStream()))
                    {
                        string str = reader.ReadToEnd();
                        return str;
                    }
                }, TaskContinuationOptions.OnlyOnRanToCompletion);
            }

            catch (System.Threading.Tasks.TaskCanceledException TaskCancellation)
            {
                System.Diagnostics.Debug.WriteLine("errore http post" + TaskCancellation.ToString());
                throw new OperationCanceledException();
                //return "Task Cancellation";
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("errore http post" + ex.ToString());
                return "ERROR";
            }
        }





        public void GetWheatherCity(FormatType format, string city)
        {

            //Create web url
            var connectionString = GetConnectionUrl(format) + "&q=" + city;
            var url = new Uri(connectionString);
            var webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.BeginGetResponse(new AsyncCallback(GetResponseCallback), webRequest);
        }

        public void GetResponseCallback(IAsyncResult result)
        {
            var request = result.AsyncState as HttpWebRequest;
            if (request != null)
            {
                try
                {
                    WebResponse response = request.EndGetResponse(result);
                    var responseStream = response.GetResponseStream();
                    var streamReader = new StreamReader(responseStream, Encoding.UTF8);
                    var responseString = streamReader.ReadToEnd();
                    Debug.WriteLine(responseStream);
                }
                catch (WebException e)
                {
                    Debug.WriteLine("Error in get City.");
                    return;
                }
            }
        }
    }
}
