using RevenueServices.Inrerfaces;
using RevenueServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace RevenueServices
{
    public class RsClient : IRsClient
    {
        public static HttpClient Client { get; set; }

        static RsClient()
        {
            Client = new HttpClient();
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.BaseAddress = new Uri("https://eapi.rs.ge/");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        private static void RefreshToken(string token)
        {
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        public Task<RsResponse<TokenModelOneStep>> Authenticate(UserModel userModel)
        {
            return null;
        }
        /// <summary>
        /// ავტორიზაცია ერთბიჯიანი
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>
        public static async Task<RsResponse<TokenModelOneStep>> Authenticatex(UserModel userModel)
        {
            string url = "Users/Authenticate";

            Dictionary<string, string> param = new Dictionary<string, string>()
            {
                {"USERNAME", userModel.UserName},
                {"PASSWORD", userModel.Password},
                {"AUTH_TYPE", userModel.AuthType},
                {"DEVICE_CODE", userModel.DeviceCode}
            };

            FormUrlEncodedContent content = new FormUrlEncodedContent(param);


            using (HttpResponseMessage response = await Client.PostAsJsonAsync(url, param))
            {
                RsResponse<TokenModelOneStep> result = await response.Content.ReadAsAsync<RsResponse<TokenModelOneStep>>();
                RefreshToken(result.Data.AccessToken);
                return result;
            }
        }
        /// <summary>
        /// სისტემიდან გამოსვლა
        /// </summary>
        /// <returns></returns>
        public static async Task<RsResponse<UserModel>> LogOut()
        {
            string url = "Users/SignOut";

            bool isLogOut = false;
            Dictionary<string, string> param = new Dictionary<string, string>();
            FormUrlEncodedContent content = new FormUrlEncodedContent(param);

            using (HttpResponseMessage response = await Client.PostAsync(url, content))
            {
                RsResponse<UserModel> result = await response.Content.ReadAsAsync<RsResponse<UserModel>>();
                return result;
            }
        }

        public static async Task<RsResponse<bool>> GetVatPayer(string tin, DateTime date)
        {
            string url = "/Org/GetVatPayerStatus";
            Dictionary<string, string> param = new Dictionary<string, string>()
            {
                {"Tin", tin},
                {"VatDate", date.ToString("s")}
            };
            FormUrlEncodedContent content = new FormUrlEncodedContent(param);
            using (HttpResponseMessage response = await Client.PostAsync(url, content))
            {
                RsResponse<bool> result = await response.Content.ReadAsAsync<RsResponse<bool>>();
                return result;
            }
        }

    }
}
