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
using Wheather.Library;
using Windows.Devices.Geolocation;

namespace Wheather.View
{
    public partial class ViewCityList : PhoneApplicationPage
    {

        private ViewModelCityList WMCityList;
        public ViewCityList()
        {
            InitializeComponent();
            WMCityList = new ViewModelCityList();
            this.list.DataContext = WMCityList.Cities;
        }


        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            await WMCityList.GetCityList();
            base.OnNavigatedTo(e);
        }


        /// <summary>
        /// Navigate to List of City from coordinate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GpsButton_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/View/ViewSelectCity.xaml", UriKind.Relative));
        }

        private async void SearchButton_Click(object sender, EventArgs e)
        {
            if (this.textSearch.Text.Any())
            {
                if (!Library.Data.GetSavedCity().Contains(this.textSearch.Text))
                    Library.Data.GetSavedCity().Add(this.textSearch.Text);

                await WMCityList.GetCityList();
            }
        }

        /// <summary>
        /// Clear text box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            this.textSearch.Text = "";
        }

        private void list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

    }
}