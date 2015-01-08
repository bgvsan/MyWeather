using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using Wheather.Model;

namespace Wheather.Converter
{
    public class CodToImagePathConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            if (value != null)
            {
                try
                {
                    var icon = ((List<Wheather.Library.Weather>)(value)).First().icon; ;
                    return "/Resources/Images/Condition/" + icon + ".jpg";
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }


    public class CodToSmallImagePathConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            if (value != null)
            {
                try
                {
                    var icon = ((List<Wheather.Library.Weather>)(value)).First().icon; ;
                    return "/Resources/Images/SmallCondition/" + icon + ".png";
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }




    }


    public class KelvintToCelsius : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var result = "--";
            try{
                 var temp = ((double)value - 273.15);
                result = string.Format("{0:0}",temp);

            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error Convert to Celsius result");
            }
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


    public class TimeStampToHourMinutesString : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var result = "--";
            try
            {
                result = TimeSpan.FromSeconds(System.Convert.ToDouble(value)).ToString(@"hh\:mm");

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error Convert to Time string");
            }
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


    
}





