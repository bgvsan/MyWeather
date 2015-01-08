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
    public class ViewModelCity : INotifyPropertyChanged
    {

        public City CurrentCiy;
        public event PropertyChangedEventHandler PropertyChanged;

        public ViewModelCity()
        {
            //update();
        }

        private static City _CurrentCity = new City();
        public City GetCurrentCity
        {
            get
            {
                return _CurrentCity;
            }
            set
            {
                _CurrentCity = value;
                NotifyPropertyChanged("GetCurrentCity");
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



        /// <summary>
        /// Update to cities
        /// </summary>
        /// <param name="cityName"></param>
        private async void update(string cityName = "London")
        {
            var connection = new WhConnection();
            try
            {
                var result = await connection.GetWheather(WhConnection.FormatType.Json, cityName);
                System.Diagnostics.Debug.WriteLine(result);
                var city = JsonConvert.DeserializeObject<City>(result);
                if (city.Cod == "404")
                {
                    //City not found
                    MessageBox.Show("City not Found :" + cityName);
                }
                else
                {
                    GetCurrentCity = city;           
                    System.Diagnostics.Debug.WriteLine("City found");
                }
            }


            catch (OperationCanceledException opCancEx)
            {
                System.Diagnostics.Debug.WriteLine("OperationCanceledException");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("ex");
            }

        }


    }
}

