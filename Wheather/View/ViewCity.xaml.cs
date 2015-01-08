using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Wheather.ViewModels;

namespace Wheather.View
{
    public partial class WiewCity : PhoneApplicationPage
    {
        private ViewModelCity VMCity;
        public WiewCity()
        {
            InitializeComponent();
            VMCity = new ViewModelCity();
            this.LayoutRoot.DataContext = VMCity.GetCurrentCity;
            VMCity.PropertyChanged += VMCity_PropertyChanged;
        }

        void VMCity_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            this.LayoutRoot.DataContext = VMCity.GetCurrentCity;
        }


        /// <summary>
        /// Get saved list City
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSavedCities_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Search for a City
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSearchCity_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/View/ViewSearch.xaml?parameter=text", UriKind.Relative));
        }

        /// <summary>
        /// Find list of city from gps coord
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnGpsCoord_Click(object sender, EventArgs e)
        {
            try
            {
                NavigationService.Navigate(new Uri("/View/ViewSearch.xaml?parameter=gps", UriKind.Relative));
            }
            catch   (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error gps retrive");
            }
           
            //Get coord
           
            
        }

    }
}