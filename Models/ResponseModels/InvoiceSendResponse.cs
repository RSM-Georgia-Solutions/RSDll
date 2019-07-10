using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevenueServices.Models.ResponseModels
{
    public class InvoiceSendResponse
    {
        [JsonProperty("INVOICE_ID")]
        public int InvoiceId { get; set; }
        [JsonProperty("INVOICE_NUMBER")]
        public int InvoiceNumber { get; set; }
        [JsonProperty("SELLER_ACTION")]
        public int SellerAction { get; set; }
        [JsonProperty("BUYER_ACTION")]
        public int BuyerAction { get; set; }
    }
}
