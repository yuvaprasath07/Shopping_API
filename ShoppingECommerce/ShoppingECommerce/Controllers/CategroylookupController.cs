using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingEcommerceLogic.InterFace;

namespace ShoppingECommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategroylookupController : ControllerBase
    {
        public readonly Icategroylogic _Categroylogic;

        public CategroylookupController(Icategroylogic Categroylogic)
        {
            _Categroylogic = Categroylogic;
        }

        [HttpGet("GetCategory")]
        public IActionResult GetSp()
        {
            var categroylookup = _Categroylogic.categroylookup();
            return Ok(categroylookup);
        }
    }
}
