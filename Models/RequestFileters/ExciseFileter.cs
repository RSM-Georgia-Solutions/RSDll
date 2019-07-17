using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevenueServices.Models.ResponseModels
{
    public class ExciseFileter : IFilter
    {
        [JsonProperty("PRODUCT_NAME")]
        public string ItemName { get; set; }
        [JsonProperty("EFFECT_DATE")]
        public DateTime EffectDate { get; set; }
        [JsonProperty("END_DATE")]
        public DateTime EndDate { get; set; }
        [JsonProperty("MAXIMUM_ROWS")]
        public int MaxsimumRows { get; set; }

        public ExciseFileter()
        {
            ItemName = string.Empty;
        }
    }
}
