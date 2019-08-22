using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevenueServices.Models.ResponseModels
{
    public class OrgInfoResponse
    {
        public string Tin { get; set; }
        public string Address { get; set; }
        public bool IsVatPayer { get; set; }
        public bool IsDiplomat { get; set; }
        public string Name { get; set; }
    }
}
