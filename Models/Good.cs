using Newtonsoft.Json;
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
        [JsonProperty("EXCISE_AMOUNT_TXT")]
        public double? ExciseAmountTxt { get; set; }
        [JsonProperty("EXCISE_ID")]
        public int? ExciseId { get; set; }
        [JsonProperty("EXCISE_UNIT_PRICE")]
        public double? ExciseUnitPrice { get; set; }


    }
}
