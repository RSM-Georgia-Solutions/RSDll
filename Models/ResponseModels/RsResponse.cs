using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevenueServices
{
    public class RsResponse<TData>
    {
        public TData Data { get; set; }
        public RsStatus Status { get; set; }
    }
}
