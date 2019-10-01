using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RevenueServices
{
    public class RsResponse<TData> : IRsResponse
    {
        [JsonProperty("DATA")]
        public TData Data { get; set; }
        [JsonProperty("STATUS")]
        public RsStatus Status { get; set; }
    }
}
