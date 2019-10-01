using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevenueServices.DumbJsonModels
{
    [JsonObject("DATA")]
    public class InvoicesModelAp
    {
        [JsonProperty("Data")]
        public Invoices Invoies { get; set; }
        public Summary Summary { get; set; }
    }
}
