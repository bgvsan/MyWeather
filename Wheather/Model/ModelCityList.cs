using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wheather.Library;

namespace Wheather.Model
{
    public class City : INotifyPropertyChanged
    {


        private string _message;
        public string Message {
            get { return _message; }
            set { _message = value;
            RaisePropertyChanged("Message");
            }
        }

        private string _cod;
        public string Cod
        {
            get { return _cod; }
            set
            {
                _cod = value;
                RaisePropertyChanged("Cod");
            }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                RaisePropertyChanged("Name");
            }
        }


        private Coord _coord;
        public Coord Coord
        {
            get { return _coord; }
            set
            {
                _coord = value;
                RaisePropertyChanged("Coord");
            }
        }

        private Sys _sys;
        public Sys Sys
        {
            get { return _sys; }
            set
            {
                _sys = value;
                RaisePropertyChanged("Sys");
            }
        }

        private List<Weather> _weather;
        public List<Weather> Weather
        {
            get { return _weather; }
            set
            {
                _weather = value;
                RaisePropertyChanged("Weather");
            }
        }

        private Main _main;
        public Main Main
        {
            get { return _main; }
            set
            {
                _main = value;
                RaisePropertyChanged("Main");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}

