using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevenueServices.Models.ResponseModels
{
    public class BarCodeModel
    {
        [JsonProperty("BARCODE")]
        public string BarCode { get; set; }
        [JsonProperty("GOODS_NAME")]
        public string ItemName { get; set; }
        [JsonProperty("UNIT_ID")]
        public int UnitId { get; set; }
        [JsonProperty("UNIT_TXT")]
        public string UnitText { get; set; }
        [JsonProperty("VAT_TYPE")]
        public int VatType { get; set; }
        [JsonProperty("VAT_TYPE_TXT")]
        public string VatTypeText { get; set; }
        [JsonProperty("UNIT_PRICE")]
        public double UnitPrice { get; set; }
    }

    public class BarCodesResponse
    {        
        [JsonProperty("RESULT")]
        BarCodeModel barCodeModel;
    }
}
