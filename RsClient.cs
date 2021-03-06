﻿using Newtonsoft.Json;
using RevenueServices.DumbJsonModels;
using RevenueServices.Inrerfaces;
using RevenueServices.Models;
using RevenueServices.Models.RequestFileters;
using RevenueServices.Models.RequestModels;
using RevenueServices.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace RevenueServices
{
    public sealed class RsClient : IRsClient
    {
        private static HttpClient Client { get; set; }
        private static UserModel _userModel;
        private static TokenOneStepResponse _token;
        private static JsonMediaTypeFormatter _formatter;

        public RsClient()
        {
            Client = new HttpClient();
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented
            };
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.BaseAddress = new Uri("https://eapi.rs.ge");
            _formatter = new JsonMediaTypeFormatter
            {
                SerializerSettings = {NullValueHandling = NullValueHandling.Ignore}
            };
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _token = new TokenOneStepResponse();
            //DD-MM-YYYY 24HH:MI:SS.
        }

        /// <summary>
        /// Token-ის განახლება
        /// </summary>
        /// <param name="token"></param>
        public void RefreshToken(string token)
        {
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }
        /// <summary>
        /// Token-ის ვალიდურობის შემოწმება/განახლება თუ ავტორიზირებული მომხმარებელია
        /// </summary>
        /// <returns></returns>
        private async Task ValidateToken()
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
        }


        /// <summary>
        /// ავტორიზაცია ერთბიჯიანი
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>
        public async Task<RsResponse<TokenOneStepResponse>> Authenticate(UserModel userModel)
        {
            string url = "/Users/Authenticate";
            var dummy = JsonConvert.SerializeObject(userModel);

            using (HttpResponseMessage response = await Client.PostAsJsonAsync(url, userModel))
            {
                _userModel = userModel;
                var res = response.Content.ReadAsStringAsync();
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
        public async Task<RsResponse<UserModel>> LogOut()
        {
            const string url = "/Users/SignOut";
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
        public async Task<RsResponse<VatPayerResponse>> GetVatPayer(VatPayerModel vatPayerModel)
        {
            const string url = "/Org/GetVatPayerStatus";
            await ValidateToken();

            using (HttpResponseMessage response = await Client.PostAsJsonAsync(url, vatPayerModel))
            {
                RsResponse<VatPayerResponse> result = await response.Content.ReadAsAsync<RsResponse<VatPayerResponse>>();
                return result;
            }
        }

        /// <summary>
        /// მეთოდი აბრუნებს დეკლარაციის ნომერს, გადაეცემა თარიღი
        /// </summary>
        /// <param name="operationPeriod"></param>
        /// <returns></returns>
        public async Task<RsResponse<SeqNumResponse>> GetSeqNum(DateTime operationPeriod)
        {
            const string url = "/Invoice/GetSeqNum";
            await ValidateToken();
            string date = operationPeriod.ToString("yyyyMM");
            //var operationPeriodJson = new { date };
            using (HttpResponseMessage response = await Client.PostAsJsonAsync(url, date))
            {
                RsResponse<SeqNumResponse> result = await response.Content.ReadAsAsync<RsResponse<SeqNumResponse>>();
                return result;
            }
        }
        /// <summary>
        /// საზომი ერთეულების სიის წამოღება
        /// </summary>
        /// <returns></returns>
        public async Task<RsResponse<List<UnitOfMeasuresResponse>>> GetUnitOfMeasures()
        {
            const string url = "/Common/GetUnits";
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
        public async Task<RsResponse<string>> GetTransactionResult(string transactionId) //TODO
        {
            const string url = "/Common/GetTransactionResult";
            await ValidateToken();
            var barCodeJson = new { TransactionId = transactionId };

            using (HttpResponseMessage response = await Client.PostAsJsonAsync(url, barCodeJson))
            {
                RsResponse<string> result = await response.Content.ReadAsAsync<RsResponse<string>>();
                return result;
            }
        }

        public async Task<RsResponse<InvoiceGetResponse>> GetInvoice(InvoiceModelGet invoiceModelGet)//TODO
        {
            const string url = "/Invoice/GetInvoice";
            await ValidateToken();
            using (HttpResponseMessage response = await Client.PostAsJsonAsync(url, invoiceModelGet))
            {
                var res = response.Content.ReadAsStringAsync().Result;
                RsResponse<InvoiceGetResponse> result = await response.Content.ReadAsAsync<RsResponse<InvoiceGetResponse>>();
                return result;
            }
        }

        public async Task<RsResponse<InvoiceSendResponse>> SaveInvoice(InvoiceModelPost invoice)
        {
            const string url = "/Invoice/SaveInvoice";
            await ValidateToken();

            var dummy = JsonConvert.SerializeObject(invoice);

            using (HttpResponseMessage response = await Client.PostAsJsonAsync(url, invoice))
            {
                RsResponse<InvoiceSendResponse> result = await response.Content.ReadAsAsync<RsResponse<InvoiceSendResponse>>();
                return result;
            }
        }


        public async Task<RsResponse<InvoiceSendResponse>> ActivateInvoice(InvoiceModelPost invoice)
        {
            const string url = "/Invoice/ActivateInvoice";
            await ValidateToken();
            using (HttpResponseMessage response = await Client.PostAsJsonAsync(url, invoice))
            {
                RsResponse<InvoiceSendResponse> result = await response.Content.ReadAsAsync<RsResponse<InvoiceSendResponse>>();
                return result;
            }
        }

        public async Task<RsResponse<InvoiceSendResponse>> ActivateInvoices(List<Invoice> invoices)
        {
            const string url = "/Invoice/ActivateInvoices";
            await ValidateToken();
            InvoicesModelPost invoiceList = new InvoicesModelPost
            {
                Invoices = invoices
            };

            var dummy = JsonConvert.SerializeObject(invoiceList);

            using (HttpResponseMessage response = await Client.PostAsJsonAsync(url, invoiceList))
            {
                RsResponse<InvoiceSendResponse> result = await response.Content.ReadAsAsync<RsResponse<InvoiceSendResponse>>();
                return result;
            }
        }

        public async Task<RsResponse<InvoiceSendResponse>> DeleteInvoice(InvoiceModelPost invoice)
        {
            const string url = "/Invoice/DeleteInvoice";
            await ValidateToken();
            using (HttpResponseMessage response = await Client.PostAsJsonAsync(url, invoice))
            {
                RsResponse<InvoiceSendResponse> result = await response.Content.ReadAsAsync<RsResponse<InvoiceSendResponse>>();
                return result;
            }
        }


        public async Task<RsResponse<InvoiceSendResponse>> CancelInvoice(Invoice invoice)
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

        public async Task<RsResponse<InvoiceSendResponse>> RefuseInvoice(InvoiceModelPost invoice)
        {
            string url = "/Invoice/RefuseInvoice";
            await ValidateToken();
            using (HttpResponseMessage response = await Client.PostAsJsonAsync(url, invoice))
            {
                RsResponse<InvoiceSendResponse> result = await response.Content.ReadAsAsync<RsResponse<InvoiceSendResponse>>();
                return result;
            }
        }

        public async Task<RsResponse<InvoiceSendResponse>> RefuseInvoices(List<Invoice> invoices)
        {
            const string url = "/Invoice/RefuseInvoices";
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


        public async Task<RsResponse<InvoiceSendResponse>> ConfirmInvoice(InvoiceModelPost invoice)
        {
            const string url = "/Invoice/ConfirmInvoice";
            await ValidateToken();

            var dummy = JsonConvert.SerializeObject(invoice);

            using (HttpResponseMessage response = await Client.PostAsJsonAsync(url, invoice))
            {
                RsResponse<InvoiceSendResponse> result = await response.Content.ReadAsAsync<RsResponse<InvoiceSendResponse>>();
                return result;
            }
        }

        public async Task<RsResponse<InvoiceSendResponse>> ConfirmInvoices(List<Invoice> invoices)
        {
            InvoicesModelPost invoiceList = new InvoicesModelPost
            {
                Invoices = invoices
            };
            const string url = "/Invoice/ConfirmInvoices";
            await ValidateToken();
            var dummy = JsonConvert.SerializeObject(invoiceList);
            using (HttpResponseMessage response = await Client.PostAsJsonAsync(url, invoiceList))
            {
                RsResponse<InvoiceSendResponse> result = await response.Content.ReadAsAsync<RsResponse<InvoiceSendResponse>>();
                return result;
            }
        }

        public async Task<RsResponse<ExciseResponse>> GetExciseList(ExciseFileter fileter)
        {
            const string url = "/Invoice/ListExcise";
            await ValidateToken();

            var dummy = JsonConvert.SerializeObject(fileter);
            using (HttpResponseMessage response = await Client.PostAsJsonAsync(url, fileter))
            {
                var res = response.Content.ReadAsStringAsync();
                RsResponse<ExciseResponse> result = await response.Content.ReadAsAsync<RsResponse<ExciseResponse>>();
                return result;
            }
        }

        public async Task<RsResponse<BarCodesResponse>> GetBarCodes(BarCodesFilter fileter)
        {
            const string url = "/Invoice/ListBarCodes";
            await ValidateToken();

            var dummy = JsonConvert.SerializeObject(fileter);
            using (HttpResponseMessage response = await Client.PostAsJsonAsync(url, fileter))
            {
                var res = response.Content.ReadAsStringAsync();
                RsResponse<BarCodesResponse> result = await response.Content.ReadAsAsync<RsResponse<BarCodesResponse>>();
                return result;
            }
        }

        public async Task<RsResponse<BarCodesResponse>> GetBarCode(string barCode)
        {
            const string url = "/Invoice/GetBarCode";
            await ValidateToken();
            var barCodeJson = new { barCode };
            using (HttpResponseMessage response = await Client.PostAsJsonAsync(url, barCodeJson))
            {
                RsResponse<BarCodesResponse> result = await response.Content.ReadAsAsync<RsResponse<BarCodesResponse>>();
                return result;
            }
        }

        public async Task<RsResponse<BarCodesResponse>> ClearBarCodes()
        {
            const string url = "/Invoice/ClearBarCodes";
            await ValidateToken();

            using (HttpResponseMessage response = await Client.PostAsJsonAsync(url, string.Empty))
            {
                RsResponse<BarCodesResponse> result = await response.Content.ReadAsAsync<RsResponse<BarCodesResponse>>();
                return result;
            }
        }

        public async Task<RsResponse<OrgInfoResponse>> GetOrgInfoByTin(string tin)
        {
            //Test
            const string url = "/Org/GetOrgInfoByTin";
            await ValidateToken();
            var dummy = JsonConvert.SerializeObject(tin);
            using (HttpResponseMessage response = await Client.PostAsJsonAsync(url, tin))
            {
                RsResponse<OrgInfoResponse> result = await response.Content.ReadAsAsync<RsResponse<OrgInfoResponse>>();
                return result;
            }
        }

        public static dynamic GetPropInfo(Type classType)
        {
            var props = classType.GetProperties().Select(p => new
            {
                Property = p,
                Attribute = p
                    .GetCustomAttributes(
                        typeof(JsonPropertyAttribute), true)
                    .Cast<JsonPropertyAttribute>()
                    .FirstOrDefault()
            });
            return props;
        }

        public static string GetMemberName<T, TValue>(Expression<Func<T, TValue>> memberAccess)
        {
            return ((MemberExpression)memberAccess.Body).Member.Name;
        }
        public static object GetPropValue(object src, string propName)
        {
            return src.GetType().GetProperty(propName).GetValue(src, null);
        }
        public async Task<RsResponse<List<InvoiceResponse>>> GetInvoices(InvoiceFilter filter)
        {
            const string url = "/Invoice/ListInvoices";
            await ValidateToken();
            var dummy = JsonConvert.SerializeObject(filter);
            var settings = new JsonSerializerSettings { Converters = new JsonConverter[] { new ColumnarDataToListConverter<InvoiceResponse>() } };
            using (HttpResponseMessage response = await Client.PostAsync(url, filter, _formatter))
            {
                var res = response.Content.ReadAsStringAsync().Result;
                var list = JsonConvert.DeserializeObject<List<InvoiceResponse>>(res, settings);
                RsResponse<InvoicesModelAp> result2 = await response.Content.ReadAsAsync<RsResponse<InvoicesModelAp>>();
                RsResponse<List<InvoiceResponse>> result = new RsResponse<List<InvoiceResponse>>
                {
                    Status = result2.Status,
                    Data = list
                };
                return result;
            }
        }

        public async Task<RsResponse<InvoicesModelGetGoods>> GetInvoieItems(InvoiceItemsFilter filter)
        {
            //Test
            const string url = "/Invoice/ListGoods";
            await ValidateToken();
            var dummy = JsonConvert.SerializeObject(filter);
            using (HttpResponseMessage response = await Client.PostAsJsonAsync(url, filter))
            {
                var res = response.Content.ReadAsStringAsync().Result;
                RsResponse<InvoicesModelGetGoods> result = await response.Content.ReadAsAsync<RsResponse<InvoicesModelGetGoods>>();
                return result;
            }
        }


    }
}
