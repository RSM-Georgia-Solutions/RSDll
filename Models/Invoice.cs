﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAPbobsCOM;

namespace RevenueServices.Models
{

    public class Invoice
    {

        public Invoice()
        {
            InvSerie = string.Empty;
            Number = null;
            InvCategory = 1;
            InvType = 2;
            SellerAction = 0;
            BuyerAction = 0;
            SellerAction = 0;
            OperationDate = DateTime.Now;
            TransactionStartDate = DateTime.Now;
            CorrectionReasonId = null;
            ForeignBuyer = false;
            StartAdressTransNo = string.Empty;
            EndAdressTransNo = string.Empty;
            TransType = 1;
            TransTypeTxt = string.Empty;
            TransCompanyTin = string.Empty;
            ForeignDriverTrans = false;
            DriverCountryTrans = null;
            TrailerNoTrans = string.Empty;
            PrevCorrectionId = 0;
            TempalteName = string.Empty;
            InvoiceGoods = new List<Good>();
            InvoiceAdvances = new List<InvoiceAdvance>();
            InvoiceReturns = new List<InvoiceReturn>();
            InvoiceOilDocs = new List<object>();
            InvoiceParentGoods = new List<Good>();
            InvoiceSubDistributions = new List<InvoiceAdvance>();
            _attrbuteNamesAndProps = new Dictionary<string, string>();
            var props = RsClient.GetPropInfo(typeof(Invoice));
            foreach (var prop in props)
            {
                var propertyAttributeName = prop.Attribute.PropertyName;
                var propertyName = prop.Property.Name;
                _attrbuteNamesAndProps.Add(propertyAttributeName, propertyName);
            }
        }

        [JsonProperty("ID")]
        public int? Id { get; set; }
        [JsonProperty("INV_SERIE")]
        public string InvSerie { get; set; }
        [JsonProperty("INV_NUMBER")]
        public int? Number { get; set; }
        [JsonProperty("INV_CATEGORY")]//კატეგორია: 1 - მიწოდება/მომსახურება, 2 - ხე-ტყე, 3 - ნავთობპროდუქტები, 4 - ავანსი
        public int? InvCategory { get; set; }
        [JsonProperty("INV_TYPE")]
        public int? InvType { get; set; }
        //ტიპი: 1- შიდა გადაზიდვა, 2 - ტრანსპორტირებით, 3 - ტრანსპორტირების გარეშე, 4 - დისტრიბუცია, 5 - უკან დაბრუნება, 6 - ავანსი, 7 - საცალო მიწოდებისთვის, 8 - საბითუმო მიწოდებისთვის, 9 - იმპორტირებისას დასაწყობების ადგილამდე ტრანსპორტირებისათვის, 10 - ექსპორტისას დასაწყობების ადგილიდან ტრანსპორტირებისათვის, 11 - მომსახურება
        [JsonProperty("SELLER_ACTION")]
        public int? SellerAction { get; set; }
        //ქმედება გამყიდველის მხრიდან: -2 -შაბლონი, -1 - წაშლილი, 0 - შენახული, 1 - გადაგზავნილი, 2 - გაუქმებული, 3 - კორექტირებული
        [JsonProperty("BUYER_ACTION")]
        public int? BuyerAction { get; set; }//ქმედება მყიდველის მხრიდან: 0 - დასადასტურებელი, 1 -დადასტურებული, 2 - უარყოფილი
        [JsonProperty("OPERATION_DATE")]
        [JsonConverter(typeof(DateFormatConverterWtf))]
        public DateTime? OperationDate { get; set; }
        [JsonProperty("ACTIVATE_DATE")]
        [JsonConverter(typeof(DateFormatConverterWtf))]
        public DateTime? ActivateDate { get; set; }
        [JsonProperty("CREATE_DATE")]
        [JsonConverter(typeof(DateFormatConverterWtf))]
        public DateTime? CreateDate { get; set; }
        [JsonProperty("CONFIRM_DATE")]
        [JsonConverter(typeof(DateFormatConverterWtf))]
        public DateTime? ConfirmDate { get; set; }
        [JsonProperty("REFUSE_DATE")]
        [JsonConverter(typeof(DateFormatConverterWtf))]
        public DateTime? RefuseDate { get; set; }
        [JsonProperty("REQUEST_CANCEL_DATE")]
        [JsonConverter(typeof(DateFormatConverterWtf))]
        public DateTime? RequestCanelDate { get; set; }
        [JsonProperty("DELIVERY_DATE")]
        [JsonConverter(typeof(DateFormatConverterWtf))]
        public DateTime? DeliveryDate { get; set; }
        [JsonProperty("AGREE_CANCEL_DATE")]
        [JsonConverter(typeof(DateFormatConverterWtf))]
        public DateTime? AgreeCancelDate { get; set; }
        [JsonProperty("CORRECT_DATE")]
        [JsonConverter(typeof(DateFormatConverterWtf))]
        public DateTime? CorrectionDate { get; set; }
        [JsonProperty("TRANS_START_DATE")]
        [JsonConverter(typeof(DateFormatConverterWtf))]
        public DateTime? TransactionStartDate { get; set; }
        [JsonProperty("CORRECT_REASON_ID")]
        public int? CorrectionReasonId { get; set; }
        [JsonProperty("TIN_SELLER")]
        public string SellerTin { get; set; }
        [JsonProperty("TIN_BUYER")]
        public string BuyerTin { get; set; }
        [JsonProperty("FOREIGN_BUYER")]
        public bool ForeignBuyer { get; set; }
        [JsonProperty("NAME_SELLER")]
        public string SellerName { get; set; }
        [JsonProperty("NAME_BUYER")]
        public string BuyerName { get; set; }
        [JsonProperty("SEQNUM_SELLER")]
        public int? DeclarationIdSeller { get; set; }
        [JsonProperty("SEQNUM_BUYER")]
        public int? DeclarationIdBuyer { get; set; }
        [JsonProperty("SELLER_STATUS")]
        public int? SellerStatus { get; set; }//მყიდველის სტატუსი (1 - დ.ღ.გ. გადამხდელი)
        [JsonProperty("BUYER_STATUS")]
        public int? BuyerStatus { get; set; }//გამყიდველის სტატუსი (1 - დ.ღ.გ. გადამხდელი)
        [JsonProperty("STATUS_TXT_GEO")]
        public string StatusTxtGeo { get; set; }//დოკუმენტის საბოლოო სტატუსი (მყიდველის და გამყიდველის სტატუსების კომბინაციების მიხედვით)
        [JsonProperty("STATUS_TXT_ENG")]
        public string StatusTxtEng { get; set; }//დოკუმენტის საბოლოო სტატუსი (მყიდველის და გამყიდველის სტატუსების კომბინაციების მიხედვით)ინგლისურად
        [JsonProperty("AMOUNT_FULL")]
        public double? FullAmount { get; set; }
        [JsonProperty("AMOUNT_EXCISE")]
        public double? ExciseAmount { get; set; }
        [JsonProperty("AMOUNT_VAT")]
        public double? VatAmount { get; set; }
        [JsonProperty("AMOUNT_MAX")]//ავანსის განაშთვის მაქსიმალური თანხის რაოდენობა//
        public double? MaxAmount { get; set; }
        [JsonProperty("TRANS_START_ADDRESS")]
        public string StartAdressTrans { get; set; }
        [JsonProperty("TRANS_END_ADDRESS")]
        public string EndAdressTrans { get; set; }
        [JsonProperty("TRANS_START_ADDRESS_NO")]
        public string StartAdressTransNo { get; set; }
        [JsonProperty("TRANS_END_ADDRESS_NO")]
        public string EndAdressTransNo { get; set; }
        [JsonProperty("TRANS_TYPE")]
        public int? TransType { get; set; }//ტრანსპორტირების ტიპი: 1 - საავტომობილო, 2 - გადამზიდავი საავტომობილო, 3 - სხვა, 4 - სარკინიგზო, 5 - მილსადენი, 6 - ტალონებით, 7 - პლასტიკური ბარათით, 8 - გადაწერა
        [JsonProperty("TRANS_TYPE_TXT")]
        public string TransTypeTxt { get; set; }
        [JsonProperty("TRANS_COMPANY_TIN")]
        public string TransCompanyTin { get; set; }
        [JsonProperty("TRANS_COMPANY_NAME")]
        public string TransCompanyName { get; set; }
        [JsonProperty("TRANS_DRIVER_TIN")]
        public string DriverTin { get; set; }
        [JsonProperty("TRANS_DRIVER_FOREIGN")]
        public bool ForeignDriverTrans { get; set; }
        [JsonProperty("TRANS_DRIVER_NAME")]
        public string ForeignBuyerNameTrans { get; set; }
        [JsonProperty("TRANS_DRIVER_COUNTRY")]
        public int? DriverCountryTrans { get; set; }//მძღოლი: 0 - საქართველოს მოქალაქე, 1 - უცხო ქვეყნის მოქალაქე
        [JsonProperty("TRANS_CAR_MODEL")]
        public string CarModelTrans { get; set; }//ა/მ მარკა
        [JsonProperty("TRANS_CAR_NO")]
        public string CarNumber { get; set; }//ა/მ ნომერი
        [JsonProperty("TRANS_TRAILER_NO")]
        public string TrailerNoTrans { get; set; }//ა/მ ნომერი
        [JsonProperty("TRANS_COST")]
        public double? TransCost { get; set; }
        [JsonProperty("TRANS_COST_PAYER")]
        public int? TransCostPayer { get; set; }
        [JsonProperty("INV_COMMENT")]
        public string Comment { get; set; }
        [JsonProperty("PARENT_ID")]
        public int? ParentId { get; set; }//მშობელი საგადასახადო დოკუმენტის ნომერი (დისტრიბუცია)

        [JsonProperty("PREV_CORRECTION_ID")]//წინა კორექტირებული საგადასახადო დოკუმენტის ID. შენახვის გააქტიურებისას წინა კორექტირებული ID-ის მიბმა.
        public int? PrevCorrectionId { get; set; }

        [JsonProperty("NEXT_CORRECTION_ID")]
        public int? NextCorrectionId { get; set; }
        [JsonProperty("INV_SOURCE")]//საგადასახადო დოკუმენტის ვერსია: 0 - WEB, 1 - SERVICE, 2 - MOBILE/
        public int? InvSource { get; set; }
        [JsonProperty("TEMPLATE_NAME")]
        public string TempalteName { get; set; }
        [JsonProperty("USER_ROLE")]//- გამყიდველი, 2 - მყიდველი, 3 - გადამზიდი
        public int? UserRole { get; set; }

        [JsonProperty("INVOICE_GOODS")]
        public List<Good> InvoiceGoods { get; set; }

        [JsonProperty("INVOICE_PARENT_GOODS")]
        public List<Good> InvoiceParentGoods { get; set; }
        [JsonProperty("INVOICE_RETURN")]
        public List<InvoiceReturn> InvoiceReturns { get; set; }

        [JsonProperty("INVOICE_ADVANCE")]
        public List<InvoiceAdvance> InvoiceAdvances { get; set; }

        [JsonProperty("SUB_INVOICES_DISTRIBUTION")]
        public List<InvoiceAdvance> InvoiceSubDistributions { get; set; }
        [JsonProperty("INVOICE_OIL_DOCS")]
        public List<object> InvoiceOilDocs { get; set; }
        private readonly Dictionary<string, string> _attrbuteNamesAndProps;

        public int InsertOrUpdateUdo(Company company)
        {
            Recordset recSet = (Recordset)company.GetBusinessObject(BoObjectTypes.BoRecordset);
            recSet.DoQuery($"Select DocEntry From [@RSM_RS_OINV] WHERE U_ID = {Id}");
            CompanyService oCompanyService = company.GetCompanyService();
            GeneralService oGeneralService = oCompanyService.GetGeneralService("TaxDocument");
            int docEntry = 0;
            bool updateFlag = !recSet.EoF;
            if (updateFlag)
            {
                docEntry = int.Parse(recSet.Fields.Item("DocEntry").Value.ToString());
                GeneralDataParams oGeneralParams = (GeneralDataParams)oGeneralService.GetDataInterface(GeneralServiceDataInterfaces.gsGeneralDataParams);
                oGeneralParams.SetProperty("DocEntry", docEntry);
                GeneralData oGeneralData = oGeneralService.GetByParams(oGeneralParams);
                foreach (KeyValuePair<string, string> attrbuteNamesAndProp in _attrbuteNamesAndProps)
                {
                    if (attrbuteNamesAndProp.Key == "INVOICE_OIL_DOCS" || attrbuteNamesAndProp.Key == "SUB_INVOICES_DISTRIBUTION" || attrbuteNamesAndProp.Key == "INVOICE_ADVANCE" || attrbuteNamesAndProp.Key == "INVOICE_RETURN" || attrbuteNamesAndProp.Key == "INVOICE_PARENT_GOODS" || attrbuteNamesAndProp.Key == "INVOICE_GOODS")
                    {
                        continue;
                    }
                    object valueTmp = RsClient.GetPropValue(this, attrbuteNamesAndProp.Value);
                    var value = valueTmp is bool ? valueTmp.ToString() : valueTmp ?? string.Empty;
                    oGeneralData.SetProperty($"U_{attrbuteNamesAndProp.Key}", value);
                }
                oGeneralService.Update(oGeneralData);
                return docEntry;
            }
            else
            {
                GeneralData oGeneralData = (GeneralData)oGeneralService.GetDataInterface(GeneralServiceDataInterfaces.gsGeneralData);
                foreach (KeyValuePair<string, string> attrbuteNamesAndProp in _attrbuteNamesAndProps)
                {
                    if (attrbuteNamesAndProp.Key == "INVOICE_OIL_DOCS" || attrbuteNamesAndProp.Key == "SUB_INVOICES_DISTRIBUTION" || attrbuteNamesAndProp.Key == "INVOICE_ADVANCE" || attrbuteNamesAndProp.Key == "INVOICE_RETURN" || attrbuteNamesAndProp.Key == "INVOICE_PARENT_GOODS" || attrbuteNamesAndProp.Key == "INVOICE_GOODS")
                    {
                        continue;
                    }
                    object valueTmp = RsClient.GetPropValue(this, attrbuteNamesAndProp.Value);
                    var value = valueTmp is bool ? valueTmp.ToString() : valueTmp ?? string.Empty;
                    oGeneralData.SetProperty($"U_{attrbuteNamesAndProp.Key}", value);
                }
                var res = oGeneralService.Add(oGeneralData);
                var result = res.GetProperty("DocEntry").ToString();
                return int.Parse(result);

            }
        }

    }
}
