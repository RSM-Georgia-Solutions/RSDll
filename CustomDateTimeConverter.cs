using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevenueServices
{
    //class CustomDateTimeConverter : IsoDateTimeConverter
    //{
    //    public CustomDateTimeConverter()
    //    {
    //        base.DateTimeFormat = System.Globalization.CultureInfo.InvariantCulture.DateTimeFormat.FullDateTimePattern;
    //    }
    //}
    public class DateFormatConverter : IsoDateTimeConverter
    {
        public DateFormatConverter()
        {
            base.DateTimeFormat = "dd-MM-yyyy";
        }
    }
}
