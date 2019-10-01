using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevenueServices.Models.RequestFileters
{
    public class BarCodesFilter : IFilter
    {
        [JsonProperty("BARCODE")]
        public string BarCode { get; set; }
        [JsonProperty("GOODS_NAME")]
        public string ItemName { get; set; }
        [JsonProperty("UNIT_TXT")]
        public string UnitName { get; set; }
        [JsonProperty("VAT_TYPE_TXT")]
        public string VatType { get; set; }
        [JsonProperty("UNIT_PRICE")]
        public double ItemPrice { get; set; }
        [JsonProperty("MAXIMUM_ROWS")]
        public int MaximumRows { get; set; }

        public BarCodesFilter()
        {
            BarCode = string.Empty;
            ItemName = string.Empty;
            UnitName = string.Empty;
            VatType = string.Empty;
            MaximumRows = 10;
        }
    }
}
