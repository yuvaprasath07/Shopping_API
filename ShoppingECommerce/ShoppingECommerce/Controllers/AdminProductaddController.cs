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
        public async Task<IActionResult> AdminProduct([FromForm] Addproductadmin addProductAdminModel)
        {
            var res = await _Adminproductaddlogic.AdminProductAdd(addProductAdminModel);
            return Ok(res);
        }

        [HttpGet("productGet")]
        public IActionResult productGet()
        {
            try
            {
                var getproduct = _Adminproductaddlogic.productget();

                foreach (var product in getproduct)
                {
                    /* string imageFullPath = product.Imagefilepath.Replace("\\","/");
                     string crtimagepath = imageFullPath.TrimStart("wwwroot");
                     string hostUrl = $"{Request.Scheme}://{Request.Host}{Request.PathBase}";
                     string imageUrl = $"{hostUrl}/{imageFullPath}";
                     product.Imagefilepath = imageUrl;*/

                    string imageFullPath = product.Imagefilepath.Replace("\\", "/");
                    string crtimagepath = imageFullPath.Substring(imageFullPath.IndexOf("wwwroot") + "wwwroot".Length);
                    string hostUrl = $"{Request.Scheme}://{Request.Host}{Request.PathBase}";
                    string imageUrl = $"{hostUrl}/{crtimagepath}";
                    product.Imagefilepath = imageUrl;

                }

                return Ok(getproduct);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }
    }
}
