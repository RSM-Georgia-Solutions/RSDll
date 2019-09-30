using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RevenueServices.Models.RequestFileters
{
    public class InvoiceFilter : IFilter
    {
        [JsonProperty("INV_CATEGORY")]
        public string InvCategory { get; set; }
        [JsonProperty("INV_TYPE")]
        public string InvType { get; set; }
        [JsonConverter(typeof(DateFormatConverter))]
        [JsonProperty("CREATE_DATE")]
        public DateTime CreateDate { get; set; }
        [JsonProperty("OPERATION_DATE")]
        [JsonConverter(typeof(DateFormatConverter))]
        public DateTime OperationDate { get; set; }
        [JsonProperty("MAXIMUM_ROWS")]
        public int MaxRows { get; set; }
        [JsonProperty("TYPE")]
        public int Type { get; set; }

        public InvoiceFilter()
        {
            InvCategory = "1";
            InvType = "2,3";
            CreateDate = DateTime.Now;
            OperationDate = DateTime.Now;
            MaxRows = 50;
            Type = 1;
        }
    }
}
