using Newtonsoft.Json;
using RevenueServices.Inrerfaces;
using RevenueServices.Models;
using RevenueServices.Models.RequestFileters;
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
        private static TokenOneStepResponse _token;

        static RsClient()
        {
            Client = new HttpClient();
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.BaseAddress = new Uri("https://eapi.rs.ge");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _token = new TokenOneStepResponse();            
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
                RsResponse<TokenOneStepResponse> response = await Authenticate(_userModel);
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
        public static async Task<RsResponse<TokenOneStepResponse>> Authenticate(UserModel userModel)
        {
            string url = "/Users/Authenticate";
            using (HttpResponseMessage response = await Client.PostAsJsonAsync(url, userModel))
            {
                _userModel = userModel;
                RsResponse<TokenOneStepResponse> result = await response.Content.ReadAsAsync<RsResponse<TokenOneStepResponse>>();
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
        public static async Task<RsResponse<VatPayerResponse>> GetVatPayer(VatPayerModel vatPayerModel)
        {
            string url = "/Org/GetVatPayerStatus";
            await ValidateToken();

            using (HttpResponseMessage response = await Client.PostAsJsonAsync(url, vatPayerModel))
            {
                RsResponse<VatPayerResponse> result = await response.Content.ReadAsAsync<RsResponse<VatPayerResponse>>();
                return result;
            }
        }
        /// <summary>
        /// საზომი ერთეულების სიის წამოღება
        /// </summary>
        /// <returns></returns>
        public static async Task<RsResponse<List<UnitOfMeasuresResponse>>> GetUnitOfMeasures()
        {
            string url = "/Common/GetUnits";
            await ValidateToken();
            using (HttpResponseMessage response = await Client.PostAsJsonAsync(url, string.Empty))
            {
                RsResponse<List<UnitOfMeasuresResponse>> result = await response.Content.ReadAsAsync<RsResponse<List<UnitOfMeasuresResponse>>>();
                return result;
            }
        }
        /// <summary>
        /// პასუხი ტრანზაქციის ნომრის მიხედვით
        /// </summary>
        /// <returns></returns>
        public static async Task<RsResponse<string>> GetTransactionResult(string TransactionId) //TODO
        {
            string url = "/Common/GetTransactionResult";
            await ValidateToken();
            var barCodeJson = new { TransactionId };

            using (HttpResponseMessage response = await Client.PostAsJsonAsync(url, barCodeJson))
            {
                RsResponse<string> result = await response.Content.ReadAsAsync<RsResponse<string>>();
                return result;
            }
        }

        public static async Task<RsResponse<InvoiceGetResponse>> GetInvoice(InvoiceModelGet invoiceModelGet)
        {
            string url = "/Invoice/GetInvoice";
            await ValidateToken();
            using (HttpResponseMessage response = await Client.PostAsJsonAsync(url, invoiceModelGet))
            {
                RsResponse<InvoiceGetResponse> result = await response.Content.ReadAsAsync<RsResponse<InvoiceGetResponse>> ();
                return result;
            }
        }

        public static async Task<RsResponse<InvoiceSendResponse>> SaveInvoice(Invoice invoice)
        {
            string url = "/Invoice/SaveInvoice";
            await ValidateToken();
            using (HttpResponseMessage response = await Client.PostAsJsonAsync(url, invoice))
            {
                RsResponse<InvoiceSendResponse> result = await response.Content.ReadAsAsync<RsResponse<InvoiceSendResponse>>();
                return result;
            }
        }


        public static async Task<RsResponse<InvoiceSendResponse>> ActivateInvoice(InvoiceModelPost invoice)
        {
            string url = "/Invoice/ActivateInvoice";
            await ValidateToken();
            using (HttpResponseMessage response = await Client.PostAsJsonAsync(url, invoice))
            {
                RsResponse<InvoiceSendResponse> result = await response.Content.ReadAsAsync<RsResponse<InvoiceSendResponse>>();
                return result;
            }
        }

        public static async Task<RsResponse<InvoiceSendResponse>> ActivateInvoices(List<Invoice> invoices)
        {
            string url = "/Invoice/ActivateInvoices";
            await ValidateToken();
            InvoicesModelPost invoiceList = new InvoicesModelPost
            {
                Invoices = invoices
            };
            using (HttpResponseMessage response = await Client.PostAsJsonAsync(url, invoiceList))
            {
                RsResponse<InvoiceSendResponse> result = await response.Content.ReadAsAsync<RsResponse<InvoiceSendResponse>>();
                return result;
            }
        }

        public static async Task<RsResponse<InvoiceSendResponse>> DeleteInvoice(InvoiceModelPost invoice)
        {
            string url = "/Invoice/DeleteInvoice";
            await ValidateToken();
            using (HttpResponseMessage response = await Client.PostAsJsonAsync(url, invoice))
            {
                RsResponse<InvoiceSendResponse> result = await response.Content.ReadAsAsync<RsResponse<InvoiceSendResponse>>();
                return result;
            }
        }


        public static async Task<RsResponse<InvoiceSendResponse>> CancelInvoice(Invoice invoice)
        {
            string url = "/Invoice/CancelInvoice";
            await ValidateToken();
            InvoiceModelPost invoiceModelPost = new InvoiceModelPost
            {
                Invoice = invoice
            };
            using (HttpResponseMessage response = await Client.PostAsJsonAsync(url, invoiceModelPost))
            {
                RsResponse<InvoiceSendResponse> result = await response.Content.ReadAsAsync<RsResponse<InvoiceSendResponse>>();
                return result;
            }
        }

        public static async Task<RsResponse<InvoiceSendResponse>> RefuseInvoice(InvoiceModelPost invoice)
        {
            string url = "/Invoice/RefuseInvoice";
            await ValidateToken();
            using (HttpResponseMessage response = await Client.PostAsJsonAsync(url, invoice))
            {
                RsResponse<InvoiceSendResponse> result = await response.Content.ReadAsAsync<RsResponse<InvoiceSendResponse>>();
                return result;
            }
        }

        public static async Task<RsResponse<InvoiceSendResponse>> RefuseInvoices(List<Invoice> invoices)
        {
            string url = "/Invoice/RefuseInvoices";
            await ValidateToken();
            InvoicesModelPost invoiceList = new InvoicesModelPost
            {
                Invoices = invoices
            };
            using (HttpResponseMessage response = await Client.PostAsJsonAsync(url, invoiceList))
            {
                RsResponse<InvoiceSendResponse> result = await response.Content.ReadAsAsync<RsResponse<InvoiceSendResponse>>();
                return result;
            }
        }


        public static async Task<RsResponse<InvoiceSendResponse>> ConfirmInvoice(InvoiceModelPost invoice)
        {
            string url = "/Invoice/ConfirmInvoice";
            await ValidateToken();
 
            var myContent = JsonConvert.SerializeObject(invoice);

            using (HttpResponseMessage response = await Client.PostAsJsonAsync(url, invoice))
            {
                RsResponse<InvoiceSendResponse> result = await response.Content.ReadAsAsync<RsResponse<InvoiceSendResponse>>();
                return result;
            }
        }

        public static async Task<RsResponse<InvoiceSendResponse>> ConfirmInvoices(List<Invoice> invoices)
        {
            InvoicesModelPost invoiceList = new InvoicesModelPost
            {
                Invoices = invoices
            };
            string url = "/Invoice/ConfirmInvoices";
            await ValidateToken();
            var x = JsonConvert.SerializeObject(invoiceList);
            using (HttpResponseMessage response = await Client.PostAsJsonAsync(url, invoiceList))
            {
                RsResponse<InvoiceSendResponse> result = await response.Content.ReadAsAsync<RsResponse<InvoiceSendResponse>>();
                return result;
            }
        }

        public static async Task<RsResponse<ExciseResponse>> GetExciseList(ExciseFileter fileter)
        {
            string url = "/Invoice/ListExcise";
            await ValidateToken();

            var x = JsonConvert.SerializeObject(fileter);
            using (HttpResponseMessage response = await Client.PostAsJsonAsync(url, fileter))
            {
                RsResponse<ExciseResponse> result = await response.Content.ReadAsAsync<RsResponse<ExciseResponse>>();
                return result;
            }
        }

        public static async Task<RsResponse<BarCodesResponse>> GetBarCodes(BarCodesFilter fileter)
        {
            string url = "/Invoice/ListBarCodes";
            await ValidateToken();

            var x = JsonConvert.SerializeObject(fileter);
            using (HttpResponseMessage response = await Client.PostAsJsonAsync(url, fileter))
            {
                RsResponse<BarCodesResponse> result = await response.Content.ReadAsAsync<RsResponse<BarCodesResponse>>();
                return result;
            }
        }

        public static async Task<RsResponse<BarCodesResponse>> GetBarCode(string barCode)
        {
            string url = "/Invoice/GetBarCode";
            await ValidateToken();
            var barCodeJson = new { barCode };
            using (HttpResponseMessage response = await Client.PostAsJsonAsync(url, barCodeJson))
            {
                RsResponse<BarCodesResponse> result = await response.Content.ReadAsAsync<RsResponse<BarCodesResponse>>();
                return result;
            }
        }

        public static async Task<RsResponse<BarCodesResponse>> ClearBarCodes()
        {
            string url = "/Invoice/ClearBarCodes";
            await ValidateToken();
           
            using (HttpResponseMessage response = await Client.PostAsJsonAsync(url, string.Empty))
            {
                RsResponse<BarCodesResponse> result = await response.Content.ReadAsAsync<RsResponse<BarCodesResponse>>();
                return result;
            }
        }



    }
}
