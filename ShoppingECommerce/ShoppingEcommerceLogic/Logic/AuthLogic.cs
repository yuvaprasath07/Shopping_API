using Microsoft.Extensions.Configuration;
using ShoppingEcomerceCommon.Helper;
using ShoppingEcomerceCommon.Model;
using ShoppingEcomerceCommon.Model.Viewmodel;
using ShoppingEcommerceLogic.InterFace;
using ShoppingEcommerceRepo.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingEcommerceLogic.Logic
{
    public class AuthLogic : IAuthLogic
    {
        private readonly IAuthrepo _authrepo;
        private readonly IConfiguration _config;
        public AuthLogic(IAuthrepo authrepo, IConfiguration config)
        {
            _authrepo = authrepo;
            _config = config;
        }

        public async Task<string> Login(LoginModel loginModel)
        {
            GenerateToken token = new GenerateToken(_config);
            var data = await _authrepo.Login(loginModel);
            if (data.Email != null)
            {
               return token.generateJWTToken(data);
            }
            else
            {
                return null;
            }
        }

        public async Task<ResponseMessage> Register(RegisterShoppingVM RegiterModel)
        {
            var res = await _authrepo.Register(RegiterModel);
            return ResponseMessage.New(ResponseCode.OK, "Register sucess");
        }
    }
}
