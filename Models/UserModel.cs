using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevenueServices
{
    public class UserModel
    {        
        public string UserName { get; set; }
        public string Password { get; set; }
        public string AuthType { get; set; }
        public string DeviceCode { get; set; }

        public UserModel()
        {
            AuthType = "1";
        }
    }
}
