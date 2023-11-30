using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingEcomerceCommon.Model;
using ShoppingEcommerceLogic.InterFace;
using ShoppingEcommerceLogic.Logic;

namespace ShoppingECommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddcartController : ControllerBase
    {

        private readonly Iaddcartlogic _addcartlogic;

        public AddcartController(Iaddcartlogic addcartlogic)
        {
            _addcartlogic = addcartlogic;
        }

        [HttpPost("productAddcart")]
        public async Task<IActionResult> AdminProduct(Addcart addcart)
        {
            var res = await _addcartlogic.productaddcart(addcart);
            return Ok(res);
        }
    }
}
