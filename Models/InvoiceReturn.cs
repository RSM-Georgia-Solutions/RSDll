using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevenueServices.Models
{
    public class InvoiceReturn
    {
        [JsonProperty("RETURN_INVOICE_ID")]
        public int? InvoiceId { get; set; }
        [JsonProperty("CORRECTED_INVOICE_ID")]
        public int? CorrectedInvoiceId { get; set; }
        [JsonProperty("INV_NUMBER")]
        public int? invoiceNumber { get; set; }
        [JsonProperty("INV_SERIE")]
        public string InvSerie { get; set; }
        [JsonProperty("INV_STATUS")]
        public string InvStatus { get; set; }
        [JsonProperty("BUYER")]
        public string Buyer { get; set; }
        [JsonProperty("OPERATION_DATE")]
        [JsonConverter(typeof(DateFormatConverterWtf))]
        public DateTime? OperationDate { get; set; }

    }
}
