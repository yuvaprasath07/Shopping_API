using ShoppingEcomerceCommon.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingEcommerceLogic.InterFace
{
    public interface Iadminproductaddlogic
    {
      Task<ResponseMessage?> AdminProductAdd(Addproductadmin addProductAdminModel);
    }
}
