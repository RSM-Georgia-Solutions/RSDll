using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevenueServices.Models.RequestModels
{
    public class VatPayerModel
    {
        public string Tin { get; set; }
        public DateTime VatDate { get; set; }
    }
}
