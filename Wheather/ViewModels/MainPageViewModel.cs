using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Wheather.Annotations;
using Wheather.Library;

namespace Wheather.ViewModels
{
    public class MainPageViewModel 
    {
        // public event PropertyChangedEventHandler PropertyChanged;


        //    private  WhCity _mainCity = new WhCity();

        //    public  WhCity MainCity
        //    { get
        //        {
        //            return _mainCity;
        //        }
        //        set{
        //            _mainCity = value;
        //            NotifyPropertyChanged("MainCity");
        //        }
        //    }


        //    public async Task UpdateCity()

        //    {
        //        var connection = new WhConnection();
        //        var result =  await connection.GetWheather(WhConnection.FormatType.Json, "London");
        //        _mainCity = JsonConvert.DeserializeObject<WhCity>(result);
        //        Debug.WriteLine(result);

        //    }
        //    protected void NotifyPropertyChanged(string propertyName)
        //    {
        //        PropertyChangedEventHandler handler = PropertyChanged;
        //        if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        //    }
        }
    }
