using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevenueServices.Models
{
    public class InvoiceAdvance
    {
        [JsonProperty("ID")]
        public int? Id { get; set; }
        [JsonProperty("OPERATION_DATE")]
        [JsonConverter(typeof(CustomDateTimeConverter))]
        public DateTime? OperationDate { get; set; }
        [JsonProperty("AMOUNT")]
        public double? Amount { get; set; }
        [JsonProperty("INV_NUMBER")]
        public string InvNumber { get; set; }
        [JsonProperty("INV_SERIE")]
        public string InvSerie { get; set; }

        [JsonProperty("INV_STATUS")]
        public string InvStatus { get; set; }
        [JsonProperty("BUYER")]
        public string Buyer { get; set; }
        [JsonProperty("SELLER")]
        public string Seller { get; set; }
        [JsonProperty("INV_CATEGORY")]
        public int? InvCategory { get; set; }
        [JsonProperty("INV_TYPE")]
        public int? InvType { get; set; }
        [JsonProperty("AMOUNT_FULL")]
        public double? FullAmount { get; set; }
        [JsonProperty("AMOUNT_MAX")]
        public double? MaxAmount { get; set; }
        [JsonProperty("ACTIVATE_DATE")]
        [JsonConverter(typeof(CustomDateTimeConverter))]
        public DateTime? ActivationDate { get; set; }
    }
}
