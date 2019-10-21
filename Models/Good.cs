using Newtonsoft.Json;
using SAPbobsCOM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevenueServices.Models
{
    public class Good
    {
        [JsonProperty("ID")]
        public int? Id { get; set; }
        [JsonProperty("INVOICE_ID")]
        public int? InvoiceId { get; set; }
        [JsonProperty("INV_TYPE")]
        public int? InvType { get; set; }
        [JsonProperty("INV_CATEGORY")]
        public int? InvCategory { get; set; }
        [JsonProperty("GOODS_NAME")]
        public string GoodName { get; set; }
        [JsonProperty("BARCODE")]
        public string BarCode { get; set; }
        [JsonProperty("UNIT_ID")]
        public int? UnitId { get; set; }
        [JsonProperty("UNIT_TXT")]
        public string UnitTxt { get; set; }

        [JsonProperty("QUANTITY")]
        public double? Quantity { get; set; }

        [JsonProperty("QUANTITY_EXT")]
        public double? QuantityExt { get; set; }
        [JsonProperty("QUANTITY_STOCK")]
        public double? QuantityStock { get; set; }

        [JsonProperty("QUANTITY_MAX")]
        public double? QuantityMax { get; set; }
        [JsonProperty("QUANTITY_USED")]
        public double? QuantityUsed { get; set; }

        [JsonProperty("QUANTITY_FULL")]
        public double? QuantityFull { get; set; }
        [JsonProperty("SSF_CODE")]
        public double? SsfCode { get; set; }//ნავთობი
        [JsonProperty("UNIT_PRICE")]
        public double? UnitPrice { get; set; }
        [JsonProperty("AMOUNT")]
        public double? Amount { get; set; }
        [JsonProperty("VAT_AMOUNT")]
        public double? VatAmount { get; set; }
        [JsonProperty("VAT_TYPE")]
        public int? VatType { get; set; }//დაბეგვრის ტიპი: 0 - ჩვეულებრივი, 1 - ნულოვანი, 2 - დაუბეგრავი
        [JsonProperty("VAT_TYPE_TXT")]
        public string VatTypeTxt { get; set; }
        [JsonProperty("EXCISE_AMOUNT")]
        public double? ExciseAmount { get; set; }
        [JsonProperty("EXCISE_ID")]
        public int? ExciseId { get; set; }
        [JsonProperty("EXCISE_UNIT_PRICE")]
        public double? ExciseUnitPrice { get; set; }


        public Good()
        {
            attrbuteNamesAndProps = new Dictionary<string, string>();
            var props = RsClient.GetPropInfo(typeof(Good));
            foreach (var prop in props)
            {
                var propertyAttributeName = prop.Attribute.PropertyName;
                var propertyName = prop.Property.Name;
                attrbuteNamesAndProps.Add(propertyAttributeName, propertyName);
            }
        }

        private readonly Dictionary<string, string> attrbuteNamesAndProps;

        public void InsertOrUpdateUdo(Company company, int docEntry)
        {
            Recordset recSet = (Recordset)company.GetBusinessObject(BoObjectTypes.BoRecordset);
            recSet.DoQuery($"Select DocEntry, LineId From [@RSM_RS_INV1] WHERE U_ID = {Id}");
            int linenum = int.Parse(recSet.Fields.Item("LineId").Value.ToString()) - 1;
            CompanyService oCompanyService = company.GetCompanyService();
            GeneralService oGeneralService = oCompanyService.GetGeneralService("TaxDocument");
            GeneralData oChild;
            GeneralDataCollection oChildren;
            bool updateFlag = !recSet.EoF;
            if (updateFlag)
            {
                GeneralDataParams oGeneralParams = (GeneralDataParams)oGeneralService.GetDataInterface(GeneralServiceDataInterfaces.gsGeneralDataParams);
                oGeneralParams.SetProperty("DocEntry", docEntry);
                GeneralData oGeneralData = oGeneralService.GetByParams(oGeneralParams);
                oChildren = oGeneralData.Child("RSM_RS_INV1");
                oChild = oChildren.Item(linenum);
                foreach (KeyValuePair<string, string> attrbuteNamesAndProp in attrbuteNamesAndProps)
                {
                    object value = RsClient.GetPropValue(this, attrbuteNamesAndProp.Value);
                    oChild.SetProperty($"U_{attrbuteNamesAndProp.Key}", value ?? string.Empty);
                }
                oGeneralService.Update(oGeneralData);
            }
            else
            {
                GeneralDataParams oGeneralParams = (GeneralDataParams)oGeneralService.GetDataInterface(GeneralServiceDataInterfaces.gsGeneralDataParams);
                oGeneralParams.SetProperty("DocEntry", docEntry);
                GeneralData oGeneralData = oGeneralService.GetByParams(oGeneralParams);
                oChildren = oGeneralData.Child("RSM_RS_INV1");
                oChild = oChildren.Add();
                foreach (KeyValuePair<string, string> attrbuteNamesAndProp in attrbuteNamesAndProps)
                {
                    object value = RsClient.GetPropValue(this, attrbuteNamesAndProp.Value);
                    oChild.SetProperty($"U_{attrbuteNamesAndProp.Key}", value ?? string.Empty);
                }
                oGeneralService.Update(oGeneralData);
            }
        }
        public void InsertOrUpdateSap(Company company)
        {
            Recordset recSet = (Recordset)company.GetBusinessObject(BoObjectTypes.BoRecordset);
            recSet.DoQuery($"Select Code From [@RSM_RS_INV1] WHERE U_ID = {Id}");
            UserTable userTable = company.UserTables.Item("RSM_RS_INV1");
            bool updateFlag = !recSet.EoF;
            if (updateFlag)
            {
                userTable.GetByKey(recSet.Fields.Item("Code").Value.ToString());
            }
            foreach (Field field in userTable.UserFields.Fields)
            {
                string fieldDesc = field.Description;
                string fieldName = field.Name;
                object value = RsClient.GetPropValue(this, attrbuteNamesAndProps[fieldDesc]);
                userTable.UserFields.Fields.Item(fieldName).Value = value ?? string.Empty;
            }

            int ret = updateFlag ? userTable.Update() : userTable.Add();
            if (ret != 0)
            {
                throw new Exception(company.GetLastErrorDescription());
            }
        }
    }
}
