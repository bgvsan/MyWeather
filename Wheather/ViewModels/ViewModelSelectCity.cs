using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Wheather.Library;
using Wheather.Model;
using Windows.Devices.Geolocation;

namespace Wheather.ViewModels
{
    class ViewModelSelectCity
    {

        private string[] citiesList;
        private ObservableCollection<City> _SelectCities = new
        ObservableCollection<City>();

        public ObservableCollection<City> SelectCities
        {
            get { return _SelectCities; }
            set { _SelectCities = value; }
        }

        public async void GetSelectCities()
        {

            var geo = await GetPosition();
            if (geo != null)
            {
                var connection = new WhConnection();
                try
                {
                    var result = await connection.GetWheather(WhConnection.FormatType.Json, geo, 5);
                    SelectCities.Add(JsonConvert.DeserializeObject<City>(result));
                }
                catch (OperationCanceledException)
                {
                    MessageBox.Show("Error Retrive Cities from GPS!");
                }
            }

        }
        public async Task<Geoposition> GetPosition()
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
