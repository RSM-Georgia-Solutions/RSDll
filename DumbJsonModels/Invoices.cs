using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevenueServices.DumbJsonModels
{
    [JsonObject("Data")]
    public class Invoices
    {
        public List<string> Fields { get; set; }
        public List<List<object>> Rows { get; set; }
        public Invoices()
        {
            Rows = new List<List<object>>();
        }
    }
}
