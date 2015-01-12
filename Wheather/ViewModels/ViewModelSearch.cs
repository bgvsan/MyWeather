using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Wheather.Library;
using Wheather.Model;
using Windows.Devices.Geolocation;

namespace Wheather.ViewModels
{
    class ViewModelSearch
    {
        private ObservableCollection<City> _SearchList = new ObservableCollection<City>();
        public ObservableCollection<City> GetCitiesList
        {
            get
            {
                return _SearchList;
            }
            set
            {
                _SearchList = value;
                //NotifyPropertyChanged("GetCurrentCity");
            }

        }
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<ModelSearch.List> _SearchGPSList =
            new ObservableCollection<ModelSearch.List>();
        public ObservableCollection<ModelSearch.List> GetGPSCitiesList
        {
            get
            {
                return _SearchGPSList;
            }
            set
            {
                _SearchGPSList = value;
                NotifyPropertyChanged("GetGPSCitiesList");
            }

        }

        public void NotifyPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        WhConnection connection;

        public ViewModelSearch()
        {

        }

        public async Task Search(string city)
        {
            this.GetCitiesList.Clear();
            connection = new WhConnection();
            var result = await connection.GetWheather(WhConnection.FormatType.Json, city);
            //Check if city exist!
            var resultCity = JsonConvert.DeserializeObject<City>(result);
            if (resultCity.Cod == "404")
            {
                //City not found
                MessageBox.Show("City not Found :" + city);
            }
            else
            {
                GetCitiesList.Add(resultCity);
            }
        }



        public void Abort()
        {
            if (connection != null)
                connection.AbortRequest();
        }



        /// <summary>
        /// Get The GPS coord and call API to update cityView
        /// </summary>
        public async Task UpdateCitiesFromGPS()
        {

            var geo = await GetPosition();
            if (geo != null)
            {
                var connection = new WhConnection();
                //try
                //{
                GetGPSCitiesList.Clear();
                var result = await connection.GetWheather(WhConnection.FormatType.Json, geo, 5);

                System.Diagnostics.Debug.WriteLine(result);
                var re = (JsonConvert.DeserializeObject<ModelSearch>(result));

                GetGPSCitiesList = re.list;


                //}
                //catch (OperationCanceledException)
                //{
                //    MessageBox.Show("Error Retrive Cities from GPS!");
                //}
            }

        }

        /// <summary>
        /// Get GeoPosition
        /// </summary>
        /// <returns></returns>
        private async Task<Geoposition> GetPosition()
        {
            Geolocator geolocator = new Geolocator();
            geolocator.DesiredAccuracyInMeters = 50;

            try
            {
                Geoposition geoposition = await geolocator.GetGeopositionAsync(
                     maximumAge: TimeSpan.FromMinutes(5),
                     timeout: TimeSpan.FromSeconds(10)
                    );

                //With this 2 lines of code, the app is able to write on a Text Label the Latitude and the Longitude, given by {{Icode|geoposition}}
                System.Diagnostics.Debug.WriteLine("GPS:" + geoposition.Coordinate.Latitude.ToString("0.00") + ", " + geoposition.Coordinate.Longitude.ToString("0.00"));
                return geoposition;
            }


            //If an error is catch 2 are the main causes: the first is that you forgot to include ID_CAP_LOCATION in your app manifest. 
            //The second is that the user doesn't turned on the Location Services
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("GPS Error" + ex.ToString());
                return null;
            }
        }
    }

}

