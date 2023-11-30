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

        [HttpGet("GetCard")]
        public async Task<IActionResult> GetCard()
        {
            var res = await _addcartlogic.cartget();
            foreach (var product in res)
            {
                string imageFullPath = product.Imagefilepath.Replace("\\", "/");
                string crtimagepath = imageFullPath.Substring(imageFullPath.IndexOf("wwwroot") + "wwwroot".Length);
                string hostUrl = $"{Request.Scheme}://{Request.Host}{Request.PathBase}";
                string imageUrl = $"{hostUrl}/{crtimagepath}";
                product.Imagefilepath = imageUrl;
            }
            if (res != null)
            {
                return Ok(res);
            }
            return BadRequest();
        }
    }
}
