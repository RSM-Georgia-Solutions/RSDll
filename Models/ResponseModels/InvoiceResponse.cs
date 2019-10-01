using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RevenueServices.Models.ResponseModels
{
    public class InvoiceResponse
    {
        [JsonProperty("ID")]
        public int Id { get; set; }

        [JsonProperty("SUBUSER_ID_SELLER")]
        public int SubSellerId { get; set; }
        [JsonProperty("UNID_SELLER")]
        public int UnIdSeller { get; set; }
        [JsonProperty("INV_SERIE")]
        public string InvSerie { get; set; }

        [JsonProperty("INV_NUMBER")]
        public int InvNumber { get; set; }

        [JsonProperty("SEQNUM_SELLER")]
        public int SeqnumSeller { get; set; }
        [JsonProperty("SEQNUM_BUYER")]
        public int SeqnumBuyer { get; set; }

        [JsonProperty("INV_CATEGORY_NAME")]
        public string InvCategoryName { get; set; }

        [JsonProperty("INV_TYPE_NAME")]
        public string InvTypeName { get; set; }
        [JsonProperty("AMOUNT_FULL")]
        public double FullAmount { get; set; }
        [JsonProperty("AMOUNT_EXCISE")]
        public double ExciseAmount { get; set; }
        [JsonProperty("AMOUNT_VAT")]
        public double VatAmount { get; set; }

        [JsonProperty("DOCMOSNOM_SELLER")]
        public string DocMosNomSeller { get; set; }
        [JsonProperty("DOCMOSNOM_BUYER")]
        public string DocMosNomBuyer { get; set; }

        [JsonProperty("TRANS_START_ADDRESS")]
        public string TransStartAdress { get; set; }
        [JsonProperty("TRANS_END_ADDRESS")]
        public string TransEndAdress { get; set; }

        [JsonProperty("TRANS_START_ADDRESS_NO")]
        public string TransStartAdressNo { get; set; }
        [JsonProperty("TRANS_END_ADDRESS_NO")]
        public string TransEndAdressNo { get; set; }

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
        public double TransCost { get; set; }

        [JsonProperty("TRANS_COST_PAYER")]
        public string TransCostPayer { get; set; }

        [JsonProperty("INV_COMMENT")]
        public string InvComment { get; set; }

        [JsonProperty("DELETE_DATE")]
        public DateTime DeleteDate { get; set; }
        [JsonProperty("CREATE_DATE")]
        public DateTime CreateDate { get; set; }
        [JsonProperty("OPERATION_DATE")]
        public DateTime OperationDate { get; set; }
        [JsonProperty("ACTIVATE_DATE")]
        public DateTime ActivateDate { get; set; }
        [JsonProperty("TRANS_START_DATE")]
        public DateTime TransStartDate { get; set; }
        [JsonProperty("CONFIRM_DATE")]
        public DateTime ConfirmDate { get; set; }
        [JsonProperty("REFUSE_DATE")]
        public DateTime RefuseDate { get; set; }
        [JsonProperty("DELIVERY_DATE")]
        public DateTime DeliveryDate { get; set; }
        [JsonProperty("REQUEST_CANCEL_DATE")]
        public DateTime RequestCancelDate { get; set; }
        [JsonProperty("AGREE_CANCEL_DATE")]
        public DateTime AgreeCancelDate { get; set; }
        [JsonProperty("CORRECT_DATE")]
        public DateTime CorrectDate { get; set; }
        [JsonProperty("CHANGE_DATE")]
        public DateTime ChangeDate { get; set; }

        [JsonProperty("SELLER_ACTION")]
        public int SellerAction { get; set; }
        [JsonProperty("BUYER_ACTION")]
        public int BuyerAction { get; set; }

        [JsonProperty("SELLER_ACTION_TXT")]
        public string SellerActionTxt { get; set; }
       
        [JsonProperty("BUYER")]
        public string Buyer { get; set; }

        [JsonProperty("PARENT_INV_NUMBER")]
        public int ParentInvNumber { get; set; }

        [JsonProperty("CORRECT_REASON_ID")]
        public int CorrectReasonId { get; set; }

        [JsonProperty("TEMPLATE_NAME")]
        public string TemplateName { get; set; }

        [JsonProperty("PREV_CORRECTION_ID")]
        public int PrevCorrectionId { get; set; }
        [JsonProperty("NEXT_CORRECTION_ID")]
        public int NextCorrectionId { get; set; }
    }
}
