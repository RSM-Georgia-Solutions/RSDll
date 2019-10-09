using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevenueServices.Models
{
    public class InvoiceGetResponse
    {
        [JsonProperty("INVOICE")]
        public Invoice Invoice { get; set; }


    }
}
