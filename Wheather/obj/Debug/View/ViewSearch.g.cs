﻿#pragma checksum "C:\Users\diego_santinelli.REGIONEMARCHE\Documents\Visual Studio 2013\Projects\MyWeather\Wheather\View\ViewSearch.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "3DAD4A8C62189E433416EFF29A3361BF"
//------------------------------------------------------------------------------
// <auto-generated>
//     Il codice è stato generato da uno strumento.
//     Versione runtime:4.0.30319.34003
//
//     Le modifiche apportate a questo file possono provocare un comportamento non corretto e andranno perse se
//     il codice viene rigenerato.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace Wheather.View {
    
    
    public partial class ViewSearch : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Grid GridProgressBar;
        
        internal System.Windows.Controls.ProgressBar ProgressBar;
        
        internal System.Windows.Controls.TextBlock search;
        
        internal System.Windows.Controls.TextBox textSearch;
        
        internal System.Windows.Controls.ListBox lstBoxSearch;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/Wheather;component/View/ViewSearch.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.GridProgressBar = ((System.Windows.Controls.Grid)(this.FindName("GridProgressBar")));
            this.ProgressBar = ((System.Windows.Controls.ProgressBar)(this.FindName("ProgressBar")));
            this.search = ((System.Windows.Controls.TextBlock)(this.FindName("search")));
            this.textSearch = ((System.Windows.Controls.TextBox)(this.FindName("textSearch")));
            this.lstBoxSearch = ((System.Windows.Controls.ListBox)(this.FindName("lstBoxSearch")));
        }
    }
}

