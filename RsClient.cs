using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace RevenueServices
{
    public static class RsClient 
    {
        public static HttpClient Client { get; set; }
        private static string _token;

        static RsClient()
        {
            Client = new HttpClient();
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.BaseAddress = new Uri("https://eapi.rs.ge/");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
        }

        public static async Task<string> Authenticate()
        {
            string res = "";
            string url = "/Users/Authenticate";

            Dictionary<string, string> param = new Dictionary<string, string>()
            {
                {"USERNAME", "Tbilisi"},
                {"PASSWORD", "123456"}
            };

            var content = new FormUrlEncodedContent(param);
            using (HttpResponseMessage response = await Client.PostAsync(url, content))
            {
                if (response.IsSuccessStatusCode)
                {
                    return res;
                }
                else
                {
                    var x = response.Content;
                    return res;
                }
            }
        }

    }
}
