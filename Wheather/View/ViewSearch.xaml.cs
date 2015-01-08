using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Input;
using Wheather.ViewModels;

namespace Wheather.View
{
    public partial class ViewSearch : PhoneApplicationPage
    {

        private ViewModelSearch VMSearch;
        private string parameterValue;

        public ViewSearch()
        {
            parameterValue = "";
            ///chech if text search or gps search
            InitializeComponent();
            VMSearch = new ViewModelSearch();
            this.textSearch.KeyUp += new KeyEventHandler(textBox_KeyUp);
            VMSearch.PropertyChanged += VMSearch_PropertyChanged;

        }

        void VMSearch_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            this.LayoutRoot.DataContext = VMSearch.GetGPSCitiesList;
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            parameterValue = NavigationContext.QueryString["parameter"];
            if (!parameterValue.Equals("gps"))
            {
                this.LayoutRoot.DataContext = VMSearch.GetCitiesList;
                this.ApplicationBar.IsVisible = true;
                this.textSearch.Visibility = System.Windows.Visibility.Visible;
            }

            else
            {
                
                this.ApplicationBar.IsVisible = false;
                this.textSearch.Visibility = System.Windows.Visibility.Collapsed;
                this.LayoutRoot.DataContext = VMSearch.GetGPSCitiesList;

                await VMSearch.UpdateCitiesFromGPS();

                
            }

        }

        private void textSearch_GotFocus(object sender, RoutedEventArgs e)
        {
            this.textSearch.Text = "";
        }





        /// <summary>
        /// Hide soft Keyboard
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void textBox_KeyUp(object sender, KeyEventArgs e)
        {
            // if the enter key is pressed
            if (e.Key == Key.Enter)
            {
                // focus the page in order to remove focus from the text box
                // and hide the soft keyboard
                this.Focus();
            }
        }

        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            //Search city.
            VMSearch.Search(this.textSearch.Text);
            //Hide keyboard
            this.Focus();
        }

        private async void TextBox_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            ViewModelCity r = new ViewModelCity();
            var i = ((TextBlock)(sender)).Text;

            if (parameterValue.Equals("gps"))
            {
                //Send request to download cities parameter
                await VMSearch.Search(i);
            }

            r.GetCurrentCity = VMSearch.GetCitiesList.First();
            NavigationService.Navigate(new Uri("/View/ViewCity.xaml", UriKind.Relative));

        }

    }
}