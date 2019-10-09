using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevenueServices
{
    class CustomDateTimeConverter : IsoDateTimeConverter
    {
        public CustomDateTimeConverter()
        {
            base.DateTimeFormat = "“DD-MM-YYYY:DD-MM-YYYY";
        }
    }
    public class DateFormatConverter : IsoDateTimeConverter
    {
        public DateFormatConverter()
        {
            base.DateTimeFormat = "dd-MM-yyyy";
        }
    }
    public class DateFormatConverterWtf : IsoDateTimeConverter
    {
        public DateFormatConverterWtf()
        {
            base.DateTimeFormat = "dd-MM-yyyy HH:mm:ss";
        }
    }
}
