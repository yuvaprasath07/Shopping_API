using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingEcomerceCommon.Model;
using ShoppingEcomerceCommon.Model.Viewmodel;
using ShoppingEcommerceLogic.InterFace;

namespace ShoppingECommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthLogic _authLogic;

        public AuthController(IAuthLogic authLogic)
        {
            _authLogic = authLogic;
        }
        [HttpPost("AdminRegister")]
        public async Task<IActionResult> AdminRegister(RegisterShoppingVM adminRegiterModel)
        {
            var res = await _authLogic.Register(adminRegiterModel);
            return Ok(res);
        }

        [HttpPost("login")]
        public async Task<ResponseMessage> Login(LoginModel loginModel)
        {
            var token = _authLogic.Login(loginModel);
            if(token != null)
            {
                return await token;
            }
            return null;
        }
    }
}
