using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RevenueServices.Models.RequestFileters
{
    public class InvoiceFilter : IFilter
    {
        [JsonProperty("INV_CATEGORY")]
        public string InvCategory { get; set; }
        [JsonProperty("INV_TYPE")]
        public string InvType { get; set; }
        [JsonProperty("CREATE_DATE")]
        public string CreateDate { get; set; }
        [JsonProperty("OPERATION_DATE")]
        public string OperationDate { get; set; }
        [JsonProperty("CHANGE_DATE")]
        public string ChangeDate { get; set; }
        [JsonProperty("ACTIVATE_DATE")]
        public string ActivateDate { get; set; }
        [JsonProperty("CONFIRM_DATE")]
        public string ConfirmDate { get; set; }
        [JsonProperty("REFUSE_DATE")]
        public string RefuseDate { get; set; }
        [JsonProperty("REQUEST_CANCEL_DATE")]
        public string RequestCancelDate { get; set; }
        [JsonProperty("AGREE_CANCEL_DATE")]
        public string AgreeCancelDate { get; set; }
        [JsonProperty("CORRECT_DATE")]
        public string CorrectDate { get; set; }
        [JsonProperty("TRANS_START_DATE")]
        public string TransStartDate { get; set; }
        [JsonProperty("TRANS_NAME")]
        public string TransName { get; set; }
        [JsonProperty("TRANS_COMPANY")]
        public string TransCompany { get; set; }
        [JsonProperty("TRANS_DRIVER")]
        public string TransDriver { get; set; }
        [JsonProperty("TRANS_CAR_MODEL")]
        public string TransCarModel { get; set; }
        [JsonProperty("TRANS_CAR_NO")]
        public string TransCarNo { get; set; }
        [JsonProperty("TRANS_TRAILER_NO")]
        public string TransTrailerNo { get; set; }
        [JsonProperty("TRANS_COST")]
        public string TransCost { get; set; }
        [JsonProperty("TRANS_COST_PAYER")]
        public string TrasCostPayer { get; set; }
        [JsonProperty("SELLER_ACTION_TXT")]
        public string SellerActionTxt { get; set; }
        [JsonProperty("BUYER_ACTION_TXT")]
        public string BuyerActionTxt { get; set; }
        [JsonProperty("SELLER")]
        public string Seller { get; set; }
        [JsonProperty("BUYER")]
        public string Buyer { get; set; }
        [JsonProperty("DECL_OPERATION_PERIOD")]
        public string DeclOperationPeriod { get; set; }

        [JsonProperty("MAXIMUM_ROWS")]
        public int MaxRows { get; set; }
        [JsonProperty("TYPE")]
        public int? Type { get; set; }
        [JsonProperty("ID")]
        public int? Id { get; set; }
        [JsonProperty("PARENT_INV_NUMBER")]
        public int? ParentInvNumber { get; set; }

        [JsonProperty("ACTION")]
        public string Action { get; set; }

        public InvoiceFilter()
        {
            InvCategory = "1,2,3,4";
            InvType = "1,2,3,4,5,6,7,8,9,10,11";
            MaxRows = 50;
            Type = 1;
        }
    }
}
