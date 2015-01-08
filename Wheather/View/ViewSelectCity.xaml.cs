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
using System.IO.IsolatedStorage;
using Wheather.Library;

namespace Wheather.View
{
    public partial class ViewSelectCity : PhoneApplicationPage
    {

        private ViewModelSelectCity WMSelectCityList;

        public ViewSelectCity()
        {
            InitializeComponent();
            WMSelectCityList = new ViewModelSelectCity();
            this.list.DataContext = WMSelectCityList.SelectCities;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            WMSelectCityList.GetSelectCities();
            base.OnNavigatedTo(e);
        }

        /// <summary>
        /// Selected City from List
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CitySelect_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {

            Data.GetSavedCity().Add(((TextBlock)(sender)).Text);
            NavigationService.Navigate(new Uri("/View/ViewCityList.xaml", UriKind.Relative));
        }

    }
}