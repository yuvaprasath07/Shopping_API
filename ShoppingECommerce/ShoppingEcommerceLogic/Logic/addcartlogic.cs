using ShoppingEcomerceCommon.Model;
using ShoppingEcommerceLogic.InterFace;
using ShoppingEcommerceRepo.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingEcommerceLogic.Logic
{
    public class addcartlogic : Iaddcartlogic
    {
        private readonly Iaddcartrepo _addcartrepo;

        public addcartlogic(Iaddcartrepo addcartrepo)
        {
            _addcartrepo = addcartrepo;
        }
        public async Task<ResponseMessage> productaddcart(Addcart addcart)
        {
            try
            {
                await _addcartrepo.addpcart(addcart); 

                return ResponseMessage.New(ResponseCode.OK, "Successfully added to the cart.");
            }
            catch (Exception ex)
            {
               
                return ResponseMessage.New(ResponseCode.BadRequest, "Failed to add to the cart. " + ex.Message);
            }
        }


    }
}
