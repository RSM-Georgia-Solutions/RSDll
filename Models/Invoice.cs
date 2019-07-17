using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevenueServices.Models
{

    public class Invoice
    {
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
        public int? ByerAction { get; set; }//ქმედება მყიდველის მხრიდან: 0 - დასადასტურებელი, 1 -დადასტურებული, 2 - უარყოფილი
        [JsonProperty("OPERATION_DATE")]       
        public DateTime? OperationDate { get; set; }
        [JsonProperty("ACTIVATE_DATE")]      
        public DateTime? ActivationDate { get; set; }
        [JsonProperty("CREATE_DATE")]       
        public DateTime? CreateDate { get; set; }
        [JsonProperty("CONFIRM_DATE")]        
        public DateTime? ConfirmDate { get; set; }
        [JsonProperty("REFUSE_DATE")]  
        public DateTime? RefuseDate { get; set; }
        [JsonProperty("REQUEST_CANCEL_DATE")]      
        public DateTime? RequestCanelDate { get; set; }
        [JsonProperty("DELIVERY_DATE")]
        public DateTime? DeliveryDate { get; set; }
        [JsonProperty("AGREE_CANCEL_DATE")]
        public DateTime? AgreeCancelDate { get; set; }
        [JsonProperty("CORRECT_DATE")]
        public DateTime? CorrectionDate { get; set; }
        [JsonProperty("TRANS_START_DATE")]
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
        [JsonProperty("AMOUNT_MAX")]//ავანსის განაშთვის მაქსიმალური თანხის რაოდენობა
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
        public string DriverNameTrans { get; set; }
        [JsonProperty("TRANS_DRIVER_FOREIGN")]
        public bool ForeignBuyerTrans { get; set; }
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
        public int? Comment { get; set; }
        [JsonProperty("PARENT_ID")]
        public int? ParentId { get; set; }//მშობელი საგადასახადო დოკუმენტის ნომერი (დისტრიბუცია)

        [JsonProperty("PREV_CORRECTION_ID")]//წინა კორექტირებული საგადასახადო დოკუმენტის ID. შენახვის გააქტიურებისას წინა კორექტირებული ID-ის მიბმა.
        public int? PrevCorrectionId { get; set; }

        [JsonProperty("NEXT_CORRECTION_ID")]
        public int? NextCorrectionId { get; set; }
        [JsonProperty("INV_SOURCE")]//საგადასახადო დოკუმენტის ვერსია: 0 - WEB, 1 - SERVICE, 2 - MOBILE
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
        public List<InvoiceAdvance> invoiceAdvances { get; set; }

        [JsonProperty("SUB_INVOICES_DISTRIBUTION")]
        public List<InvoiceAdvance> invoiceSubDistributions { get; set; }
        [JsonProperty("INVOICE_OIL_DOCS")]
        public List<object> InvoiceOilDocs { get; set; }

    }
}
