using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wheather.Model;

namespace Wheather.Library
{
    public class Data
    {
        #region Saved data to settings
        private static List<string> _savedCity;
        public static List<string> GetSavedCity()
        {
            if (_savedCity == null)
            {
                _savedCity = loadSettingsSavedCities();

            }

            return _savedCity;


        }

        public static void UpdateSavedCity(List<string> value)
        {
            GetSavedCity().Clear();
            foreach (var i in value)
            {
                GetSavedCity().Add(i);
            }
        }
        private static List<string> loadSettingsSavedCities()
        {
            var settings = IsolatedStorageSettings.ApplicationSettings;
            var savedlist = new List<string>();
            if (settings.Contains("SavedCities"))
            {
                var res = settings["SavedCities"].ToString();
                foreach (var i in res.Split(','))
                {
                    if (!i.Trim().Equals(""))
                        savedlist.Add(i.Trim());
                }
            }

            else
            {
                //Initiate settings
                settings.Add("SavedCities", "");

            }
            settings.Save();
            return savedlist;

        }
        public static void SaveSettings()
        {
            //Save into list
            var settings = IsolatedStorageSettings.ApplicationSettings;
            if (settings.Contains("SavedCities"))
            {
                var temp = "";
                foreach (var c in GetSavedCity())
                {
                    temp += c + ",";
                }
                if (temp.Count() > 0)
                { temp.Remove(temp.Length - 2, 1); }

                settings["SavedCities"] = temp;
                settings.Save();
            }
        }

        #endregion

        #region dataShow

        private static ObservableCollection<City> _Cities;
        public static ObservableCollection<City> GetCities
        {
            get
            {
                if (_Cities == null)
                    _Cities = new ObservableCollection<City>();
                return _Cities;
            }
            set { _Cities = value; }
        }






        

        #endregion
    }



}

