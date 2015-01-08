using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Wheather.Library;
using Wheather.Model;

namespace Wheather.ViewModels
{
    class ViewModelCityList
    {
        private string[] citieList = new string[] { "London", "Algeri", "Katmandu", "san_francisco" };
        private ObservableCollection<City> _Cities = new
        ObservableCollection<City>();

        public ObservableCollection<City> Cities
        {
            get { return _Cities; }
            set { _Cities = value; }
        }


        public async Task GetCityList()
        {
            var connection = new WhConnection();
            var cities = new List<string>();
            Cities.Clear();
            foreach (var i in  Library.Data.GetSavedCity())
            {
                try
                {
                    var result = await connection.GetWheather(WhConnection.FormatType.Json, i);
                    //Check if city exist!
                    var city = JsonConvert.DeserializeObject<City>(result);
                    if (city.Cod == "404")
                    {
                        //City not found
                        MessageBox.Show("City not Found :" + i);

                    }
                    else
                    {
                        Cities.Add(city);
                        cities.Add(i);
                    }
                }

                catch (OperationCanceledException)
                {
                    MessageBox.Show("Error Retrive message!");
                }

            }

               Library.Data.UpdateSavedCity(cities);
               Library.Data.SaveSettings();

        }

       
    }
}
