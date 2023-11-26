using ShoppingEcomerceCommon.Model;
using ShoppingEcomerceCommon.Model.Viewmodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingEcommerceLogic.InterFace
{
    public interface IAuthLogic
    {
        Task<ResponseMessage> Register(RegisterShoppingVM RegiterModel);
        Task<ResponseMessage> Login(LoginModel loginModel);
    }
}
