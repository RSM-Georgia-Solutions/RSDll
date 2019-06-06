using RevenueServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevenueServices.Inrerfaces
{
    public interface IRsClient
    {
         Task<RsResponse<TokenModelOneStep>> Authenticate(UserModel userModel);
         //Task<RsResponse<bool>> LogOut();
    }
}
