using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace Wheather.Library
{
    class WhObj 
    {
    }

    public class Coord
    {
        public float lon { get; set; }
        public float lat { get; set; }
    }

    public class Sys
    {
        public string country { get; set; }
        public int sunrise { get; set; }
        public int sunset { get; set; }
    }

    public class Weather
    {
        public int id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }

    public class Main
    {
        public double temp { get; set; }
        public float humidity { get; set; }
        public float pressure { get; set; }
        public double temp_min { get; set; }
        public double temp_max { get; set; }
        public double sea_level { get; set; }
        public double grnd_level { get; set; }
//        public List<Weather> weather { get; set; }
    }

    public class Wind
    {
        public double speed { get; set; }
        public double deg { get; set; }
    }

    public class Rain
    {
        public int __invalid_name__3h { get; set; }
    }

    public class Clouds
    {
        public int all { get; set; }
    }

   
}
