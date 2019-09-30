using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevenueServices.Models.RequestModels
{
    public class InvoiceModelPost
    {

        [JsonProperty("INVOICE")]
        public Invoice Invoice { get; set; }

    }
}
