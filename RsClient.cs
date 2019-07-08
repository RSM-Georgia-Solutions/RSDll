using Newtonsoft.Json;
using RevenueServices.Inrerfaces;
using RevenueServices.Models;
using RevenueServices.Models.RequestModels;
using RevenueServices.Models.ResponseModels;
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
        private static UserModel _userModel;
        private static TokenOneStep _token;

        static RsClient()
        {
            Client = new HttpClient();
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.BaseAddress = new Uri("https://eapi.rs.ge");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _token = new TokenOneStep();            
            //DD-MM-YYYY 24HH:MI:SS”.
        }

        /// <summary>
        /// Token-ის განახლება
        /// </summary>
        /// <param name="token"></param>
        private static void RefreshToken(string token)
        {
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }
        /// <summary>
        /// Token-ის ვალიდურობის შემოწმება/განახლება თუ ავტორიზირებული მომხმარებელია
        /// </summary>
        /// <returns></returns>
        private static async Task<bool> ValidateToken()
        {
            if (_userModel == null)
            {
                throw new Exception("Unauthorized");
            }

            if (_token.ExpireDate < DateTime.Now)
            {
                RsResponse<TokenOneStep> response = await Authenticate(_userModel);
                if (response.Status.Id != 0)
                {
                    throw new Exception(response.Status.Text);
                }
            }
            return true;
        }


        /// <summary>
        /// ავტორიზაცია ერთბიჯიანი
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>
        public static async Task<RsResponse<TokenOneStep>> Authenticate(UserModel userModel)
        {
            string url = "/Users/Authenticate";
            using (HttpResponseMessage response = await Client.PostAsJsonAsync(url, userModel))
            {
                _userModel = userModel;
                RsResponse<TokenOneStep> result = await response.Content.ReadAsAsync<RsResponse<TokenOneStep>>();
                if (result.Status.Id != 0)
                {
                    return result;
                }
                result.Data.ExpireDate = DateTime.Now.AddSeconds(result.Data.ExpiresIn - 120);
                _token = result.Data;
                RefreshToken(_token.AccessToken);
                return result;
            }
        }
        /// <summary>
        /// სისტემიდან გამოსვლა
        /// </summary>
        /// <returns></returns>
        public static async Task<RsResponse<UserModel>> LogOut()
        {
            string url = "/Users/SignOut";
            Dictionary<string, string> param = new Dictionary<string, string>();

            using (HttpResponseMessage response = await Client.PostAsJsonAsync(url, string.Empty))
            {
                RsResponse<UserModel> result = await response.Content.ReadAsAsync<RsResponse<UserModel>>();
                return result;
            }
        }
        /// <summary>
        /// დღგ-ს გადამხდელის გაგება საიდენტიფიკაციო ნომრით
        /// </summary>
        /// <param name="vatPayerModel"></param>
        /// <returns></returns>
        public static async Task<RsResponse<VatPayer>> GetVatPayer(VatPayerModel vatPayerModel)
        {
            string url = "/Org/GetVatPayerStatus";
            await ValidateToken();

            using (HttpResponseMessage response = await Client.PostAsJsonAsync(url, vatPayerModel))
            {
                RsResponse<VatPayer> result = await response.Content.ReadAsAsync<RsResponse<VatPayer>>();
                return result;
            }
        }
        /// <summary>
        /// საზომი ერთეულების სიის წამოღება
        /// </summary>
        /// <returns></returns>
        public static async Task<RsResponse<List<UnitOfMeasures>>> GetUnitOfMeasures()
        {
            string url = "/Common/GetUnits";
            await ValidateToken();
            using (HttpResponseMessage response = await Client.PostAsJsonAsync(url, string.Empty))
            {
                RsResponse<List<UnitOfMeasures>> result = await response.Content.ReadAsAsync<RsResponse<List<UnitOfMeasures>>>();
                return result;
            }
        }
        /// <summary>
        /// პასუხი ტრანზაქციის ნომრის მიხედვით
        /// </summary>
        /// <returns></returns>
        public static async Task<RsResponse<bool>> GetTransactionResult() //TODO
        {
            string url = "/Common/GetTransactionResult";
            await ValidateToken();
            using (HttpResponseMessage response = await Client.PostAsJsonAsync(url, string.Empty))
            {
                RsResponse<bool> result = await response.Content.ReadAsAsync<RsResponse<bool>>();
                return result;
            }
        }

        public static async Task<RsResponse<InvoiceResponse>> GetInvoice(InvoiceModelGet invoiceModelGet)
        {
            string url = "/Invoice/GetInvoice";
            await ValidateToken();
            using (HttpResponseMessage response = await Client.PostAsJsonAsync(url, invoiceModelGet))
            {
                RsResponse<InvoiceResponse> result = await response.Content.ReadAsAsync<RsResponse<InvoiceResponse>> ();
                return result;
            }
        }



    }
}
