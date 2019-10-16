using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SAPbobsCOM;

namespace RevenueServices.Models.ResponseModels
{
    public class InvoiceResponse
    {

        public InvoiceResponse()
        {
            DeleteDate = DateTime.MinValue;
            CreateDate = DateTime.MinValue;
            ActivateDate = DateTime.MinValue;
            AgreeCancelDate = DateTime.MinValue;
            ChangeDate = DateTime.MinValue;
            DeleteDate = DateTime.MinValue;
            TransStartDate = DateTime.MinValue;
            RequestCancelDate = DateTime.MinValue;
            RefuseDate = DateTime.MinValue;
            OperationDate = DateTime.MinValue;
            DeliveryDate = DateTime.MinValue;
            CorrectDate = DateTime.MinValue;
            attrbuteNamesAndProps = new Dictionary<string, string>();
            var props = RsClient.GetPropInfo(typeof(InvoiceResponse));
            foreach (var prop in props)
            {
                var propertyAttributeName = prop.Attribute.PropertyName;
                var propertyName = prop.Property.Name;
                attrbuteNamesAndProps.Add(propertyAttributeName, propertyName);
            }
        }

        private readonly Dictionary<string, string> attrbuteNamesAndProps;


        public void InsertOrUpdateUdo(Company company)
        {
            Recordset recSet = (Recordset)company.GetBusinessObject(BoObjectTypes.BoRecordset);
            recSet.DoQuery($"Select DocEntry From [@RSM_OINV] WHERE U_ID = {Id}");
            CompanyService oCompanyService = company.GetCompanyService();
            GeneralService oGeneralService = oCompanyService.GetGeneralService("TaxDocument");
            bool updateFlag = !recSet.EoF;
            if (updateFlag)
            {
                GeneralDataParams oGeneralParams = (GeneralDataParams)oGeneralService.GetDataInterface(GeneralServiceDataInterfaces.gsGeneralDataParams);
                oGeneralParams.SetProperty("DocEntry", recSet.Fields.Item("DocEntry").Value.ToString());
                GeneralData oGeneralData = oGeneralService.GetByParams(oGeneralParams);
                foreach (KeyValuePair<string, string> attrbuteNamesAndProp in attrbuteNamesAndProps)
                {
                    object value = RsClient.GetPropValue(this, attrbuteNamesAndProp.Value);
                    oGeneralData.SetProperty($"U_{attrbuteNamesAndProp.Key}", value ?? string.Empty);
                }
                oGeneralService.Update(oGeneralData);
            }
            else
            {
                GeneralData oGeneralData = (GeneralData)oGeneralService.GetDataInterface(GeneralServiceDataInterfaces.gsGeneralData);
                foreach (KeyValuePair<string, string> attrbuteNamesAndProp in attrbuteNamesAndProps)
                {
                    object value = RsClient.GetPropValue(this, attrbuteNamesAndProp.Value);
                    oGeneralData.SetProperty($"U_{attrbuteNamesAndProp.Key}", value??string.Empty);
                }
                oGeneralService.Add(oGeneralData);
            }
        }

        public void InsertOrUpdateSap(Company company)
        {
            Recordset recSet = (Recordset)company.GetBusinessObject(BoObjectTypes.BoRecordset);
            recSet.DoQuery($"Select Code From [@RSM_RS_OINV_HEADERS] WHERE U_ID = {Id}");
            UserTable userTable = company.UserTables.Item("RSM_RS_OINV_HEADERS");
            bool updateFlag = !recSet.EoF;
            if (updateFlag)
            {
                userTable.GetByKey(recSet.Fields.Item("Code").Value.ToString());
            }
            foreach (Field field in userTable.UserFields.Fields)
            {
                string fieldName = field.Name;
                string fieldDesc = field.Name.Remove(0, 2);
                object value = RsClient.GetPropValue(this, attrbuteNamesAndProps[fieldDesc]);
                userTable.UserFields.Fields.Item(fieldName).Value = value ?? string.Empty;
            }

            int ret = updateFlag ? userTable.Update() : userTable.Add();
            if (ret != 0)
            {
                throw new Exception(company.GetLastErrorDescription());
            }
        }

        [JsonProperty("ID")]
        public int? Id { get; set; }

        [JsonProperty("SUBUSER_ID_SELLER")]
        public int? SubSellerId { get; set; }
        [JsonProperty("UNID_SELLER")]
        public int? UnIdSeller { get; set; }
        [JsonProperty("INV_SERIE")]
        public string InvSerie { get; set; }

        [JsonProperty("INV_NUMBER")]
        public int? InvNumber { get; set; }

        [JsonProperty("SEQNUM_SELLER")]
        public int? SeqnumSeller { get; set; }
        [JsonProperty("SEQNUM_BUYER")]
        public int? SeqnumBuyer { get; set; }

        [JsonProperty("INV_CATEGORY_NAME")]
        public string InvCategoryName { get; set; }

        [JsonProperty("INV_TYPE_NAME")]
        public string InvTypeName { get; set; }
        [JsonProperty("AMOUNT_FULL")]
        public double? FullAmount { get; set; }
        [JsonProperty("AMOUNT_EXCISE")]
        public double? ExciseAmount { get; set; }
        [JsonProperty("AMOUNT_VAT")]
        public double? VatAmount { get; set; }

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
        public double? TransCost { get; set; }

        [JsonProperty("TRANS_COST_PAYER")]
        public string TransCostPayer { get; set; }

        [JsonProperty("INV_COMMENT")]
        public string InvComment { get; set; }
        [JsonConverter(typeof(DateFormatConverterWtf))]
        [JsonProperty("DELETE_DATE")]
        public DateTime? DeleteDate { get; set; }
        [JsonConverter(typeof(DateFormatConverterWtf))]
        [JsonProperty("CREATE_DATE")]
        public DateTime? CreateDate { get; set; }
        [JsonConverter(typeof(DateFormatConverterWtf))]
        [JsonProperty("OPERATION_DATE")]
        public DateTime? OperationDate { get; set; }
        [JsonConverter(typeof(DateFormatConverterWtf))]
        [JsonProperty("ACTIVATE_DATE")]
        public DateTime? ActivateDate { get; set; }
        [JsonConverter(typeof(DateFormatConverterWtf))]
        [JsonProperty("TRANS_START_DATE")]
        public DateTime? TransStartDate { get; set; }
        [JsonConverter(typeof(DateFormatConverterWtf))]
        [JsonProperty("CONFIRM_DATE")]
        public DateTime? ConfirmDate { get; set; }
        [JsonConverter(typeof(DateFormatConverterWtf))]
        [JsonProperty("REFUSE_DATE")]
        public DateTime? RefuseDate { get; set; }
        [JsonConverter(typeof(DateFormatConverterWtf))]
        [JsonProperty("DELIVERY_DATE")]
        public DateTime? DeliveryDate { get; set; }
        [JsonConverter(typeof(DateFormatConverterWtf))]
        [JsonProperty("REQUEST_CANCEL_DATE")]
        public DateTime? RequestCancelDate { get; set; }
        [JsonConverter(typeof(DateFormatConverterWtf))]
        [JsonProperty("AGREE_CANCEL_DATE")]
        public DateTime? AgreeCancelDate { get; set; }
        [JsonConverter(typeof(DateFormatConverterWtf))]
        [JsonProperty("CORRECT_DATE")]
        public DateTime? CorrectDate { get; set; }
        [JsonConverter(typeof(DateFormatConverterWtf))]
        [JsonProperty("CHANGE_DATE")]
        public DateTime? ChangeDate { get; set; }

        [JsonProperty("SELLER_ACTION")]
        public int? SellerAction { get; set; }
        [JsonProperty("BUYER_ACTION")]
        public int? BuyerAction { get; set; }

        [JsonProperty("SELLER_ACTION_TXT")]
        public string SellerActionTxt { get; set; }
        [JsonProperty("BUYER")]
        public string Buyer { get; set; }

        [JsonProperty("PARENT_INV_NUMBER")]
        public int? ParentInvNumber { get; set; }

        [JsonProperty("CORRECT_REASON_ID")]
        public int? CorrectReasonId { get; set; }

        [JsonProperty("TEMPLATE_NAME")]
        public string TemplateName { get; set; }

        [JsonProperty("PREV_CORRECTION_ID")]
        public int? PrevCorrectionId { get; set; }
        [JsonProperty("NEXT_CORRECTION_ID")]
        public int? NextCorrectionId { get; set; }
    }

}
