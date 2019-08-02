using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevenueServices.Models.RequestModels
{
    class InvoicesModelPost
    {
        [JsonProperty("Invoices")]
        public List<Invoice> Invoices { get; set; }

        public InvoicesModelPost()
        {
            Invoices = new List<Invoice>();
        }
    }
}
