using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevenueServices.Models.RequestFileters
{
    public class InvoiceItemsFilter: IFilter
    {
        [JsonProperty("TIN_SELLER")]
        public string SellerTin { get; set; }
        [JsonProperty("TIN_BUYER")]
        public string BuyerTin { get; set; }
        [JsonProperty("ACTIVATE_DATE")]        
        public string ActivateDate { get; set; }
        [JsonProperty("START_ROW_INDEX")]
        public int StartRowIndex { get; set; }
        [JsonProperty("Count")]
        public int Count { get; set; }
        public InvoiceItemsFilter()
        {

        }
    }
}
