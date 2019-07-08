using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevenueServices.Models
{
    public class InvoiceResponse
    {
        [JsonProperty("INVOICE")]
        public Invoice Invoice { get; set; }
        //[JsonProperty("INVOICE_GOODS")]
        //public List<Good> InvoiceGoods { get; set; }
        //[JsonProperty("INVOICE_PARENT_GOODS")]
        //public List<Good> InvoiceParentGoods { get; set; }
        //[JsonProperty("INVOICE_RETURN")]
        //public List<InvoiceReturn> InvoiceReturns { get; set; }
        //[JsonProperty("SUB_INVOICES_DISTRIBUTION")]
        //public List<InvoiceAdvance> InvoiceDistributions { get; set; }

        //[JsonProperty("INVOICE_ADVANCE")]
        //public List<InvoiceReturn> InvoiceAdvances { get; set; }      

    }
}
