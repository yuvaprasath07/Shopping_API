using ShoppingEcomerceCommon.Model;
using ShoppingEcomerceCommon.Model.Viewmodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingEcommerceRepo.Interface
{
    public interface IAuthrepo
    {
        Task<bool> Register(RegisterShoppingVM RegiterModel);
        Task<RegisterShoppingVM> Login(LoginModel loginModel);
    }
}
