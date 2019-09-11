using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevenueServices.Models.ResponseModels
{
    public class SeqNumResponse
    {
        [JsonProperty("SeqNum")]
        public string SeqNum { get; set; }
    }
}
