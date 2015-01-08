using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Wheather.Library;
using Wheather.Resources;
using Wheather.ViewModels;

namespace Wheather
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Costruttore
        public MainPage()
        {
            InitializeComponent();
            this.DataContext = App.MainPageViewModel;
           
           // NavigationService.Navigate(new Uri("/SecondPage.xaml", UriKind.Relative));
        }

        
        // Caricare i dati per gli elementi ViewModel
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //if (!App.MainPageViewModel.IsDataLoaded)
            //{
            //    App.MainPageViewModel.LoadData();
            //}
        }

       
        private async  void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {

            NavigationService.Navigate(new Uri("/View/ViewCity.xaml", UriKind.Relative));
           // var upd = new MainPageViewModel();
           // await upd.UpdateCity();
           
           //App.MainPageViewModel.MainCity.name = "culo";
        }
    }
}