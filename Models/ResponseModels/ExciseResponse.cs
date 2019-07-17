using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevenueServices.Models.ResponseModels
{
    public class ExciseResponse
    {
        [JsonProperty("ID")]
        public int Id { get; set; }
        [JsonProperty("PRODUCT_NAME")]
        public string ItemName { get; set; }
        [JsonProperty("UNIT_ID")]
        public int UnitId { get; set; }
        [JsonProperty("UNIT_TEXT")]
        public string UnitName { get; set; }
        [JsonProperty("EXCISE_CODE")]
        public int ExciseCode { get; set; }
        [JsonProperty("EXCISE_RATE")]
        public int ExciseRate { get; set; }
        [JsonProperty("END_DATE")]
        public string EndDate { get; set; }
        [JsonProperty("EFFECT_DATE")]
        public string EffectDate { get; set; }
        [JsonProperty("EFFECT_DATE_MONTH")]
        public string EffectDateMonth { get; set; }
    }
}
