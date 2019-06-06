using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevenueServices.Models
{
    public class TokenOneStep
    {
        [JsonProperty("ACCESS_TOKEN")]
        public string AccessToken { get; set; }
        [JsonProperty("EXPIRES_IN")]
        public int ExpiresIn { get; set; }
        [JsonProperty("MASKED_MOBILE")]
        public string MaskedMobile { get; set; }
        public DateTime ExpireDate { get; set; }

        public TokenOneStep()
        {
            ExpireDate = DateTime.MinValue;
        }
    }
}
