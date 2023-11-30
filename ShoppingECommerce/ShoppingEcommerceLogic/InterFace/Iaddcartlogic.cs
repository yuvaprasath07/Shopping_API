using ShoppingEcomerceCommon.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingEcommerceLogic.InterFace
{
    public interface Iaddcartlogic
    {
        Task<ResponseMessage?> productaddcart(Addcart addcart);
        Task<List<cartGet>> cartget();
    }
}
