using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingEcomerceCommon.Model;
using ShoppingEcomerceCommon.Model.Viewmodel;
using ShoppingEcommerceLogic.InterFace;
using ShoppingEcommerceLogic.Logic;

namespace ShoppingECommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminProductaddController : ControllerBase
    {
        private readonly Iadminproductaddlogic _Adminproductaddlogic;

        public AdminProductaddController(Iadminproductaddlogic Adminproductaddlogic)
        {
            _Adminproductaddlogic = Adminproductaddlogic;
        }

        [HttpPost("AdminProductAdd")]
        public async Task<IActionResult> AdminProduct(Addproductadmin addProductAdminModel)
        {
            var res = await _Adminproductaddlogic.AdminProductAdd(addProductAdminModel);
            return Ok(res);
        }

    }

}
