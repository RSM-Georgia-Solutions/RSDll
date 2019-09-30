using RevenueServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RevenueServices.Models.RequestFileters;
using RevenueServices.Models.RequestModels;
using RevenueServices.Models.ResponseModels;

namespace RevenueServices.Inrerfaces
{
    public interface IRsClient
    {
        void RefreshToken(string token);
        Task<RsResponse<UserModel>> LogOut();
        Task<RsResponse<TokenOneStepResponse>> Authenticate(UserModel userModel);
        Task<RsResponse<SeqNumResponse>> GetSeqNum(DateTime operationPeriod);
        Task<RsResponse<List<UnitOfMeasuresResponse>>> GetUnitOfMeasures();
        Task<RsResponse<VatPayerResponse>> GetVatPayer(VatPayerModel vatPayerModel);
        Task<RsResponse<string>> GetTransactionResult(string transactionId);
        Task<RsResponse<InvoiceGetResponse>> GetInvoice(InvoiceModelGet invoiceModelGet);
        Task<RsResponse<InvoiceSendResponse>> SaveInvoice(InvoiceModelPost invoice);
        Task<RsResponse<InvoiceSendResponse>> ActivateInvoice(InvoiceModelPost invoice);
        Task<RsResponse<InvoiceSendResponse>> ActivateInvoices(List<Invoice> invoices);
        Task<RsResponse<InvoiceSendResponse>> DeleteInvoice(InvoiceModelPost invoice);
        Task<RsResponse<InvoiceSendResponse>> CancelInvoice(Invoice invoice);
        Task<RsResponse<InvoiceSendResponse>> RefuseInvoice(InvoiceModelPost invoice);
        Task<RsResponse<InvoiceSendResponse>> RefuseInvoices(List<Invoice> invoices);
        Task<RsResponse<InvoiceSendResponse>> ConfirmInvoice(InvoiceModelPost invoice);
        Task<RsResponse<InvoiceSendResponse>> ConfirmInvoices(List<Invoice> invoices);
        Task<RsResponse<ExciseResponse>> GetExciseList(ExciseFileter fileter);
        Task<RsResponse<BarCodesResponse>> GetBarCodes(BarCodesFilter fileter);
        Task<RsResponse<BarCodesResponse>> GetBarCode(string barCode);
        Task<RsResponse<BarCodesResponse>> ClearBarCodes();
        Task<RsResponse<OrgInfoResponse>> GetOrgInfoByTin(string tin);
    }
}
