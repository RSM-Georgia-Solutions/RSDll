using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevenueServices.Models.RequestModels
{
    public class InvoiceModelGet
    {
        [JsonProperty("InvoiceID")]
        public int Id { get; set; }
        [JsonProperty("parentInvoiceID")]
        public int ParentId { get; set; }
    }
}
