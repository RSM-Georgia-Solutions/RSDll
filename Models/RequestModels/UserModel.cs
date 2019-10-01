using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RevenueServices
{
    //[JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class UserModel
    {
        [JsonProperty("USERNAME")]
        public string UserName { get; set; }
        [JsonProperty("PASSWORD")]
        public string Password { get; set; }
        [JsonProperty("AUTH_TYPE")]
        public string AuthType { get; set; }
        [JsonProperty("DEVICE_CODE")]
        public string DeviceCode { get; set; }

        public UserModel()
        {
            AuthType = "1";
        }
    }
}
