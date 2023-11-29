using ShoppingEcomerceCommon.Model;
using ShoppingEcommerceLogic.InterFace;
using ShoppingEcommerceRepo.Interface;
using ShoppingEcommerceRepo.Repositry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingEcommerceLogic.Logic
{
    public class adminproductaddlogic : Iadminproductaddlogic
    {
        private readonly Iadminproductaddrepo _iadminproductaddrepo;
        public adminproductaddlogic(Iadminproductaddrepo iadminproductaddrepo)
        {
            _iadminproductaddrepo = iadminproductaddrepo;
        }

        public async Task<ResponseMessage?> AdminProductAdd(Addproductadmin addProductAdminModel)
        {
            try
            {
                if (addProductAdminModel.Imagefilepath == null || addProductAdminModel.Imagefilepath.Length == 0)
                {
                    return ResponseMessage.New(ResponseCode.BadRequest, "Image file is required.");
                }

                string username = addProductAdminModel.model;
                string userFolderPath = Path.Combine("wwwroot", "ProductImages");

                if (!Directory.Exists(userFolderPath))
                {
                    Directory.CreateDirectory(userFolderPath);
                }

                string timestamp = DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss");
                string uniqueFileName = $"{username}_{timestamp}{Path.GetExtension(addProductAdminModel.Imagefilepath.FileName)}";

                string imagePath = Path.Combine(userFolderPath, uniqueFileName);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    await addProductAdminModel.Imagefilepath.CopyToAsync(stream);
                }

                AddproductadminDB dbvalu = new AddproductadminDB()
                {
                    model = addProductAdminModel.model,
                    category = addProductAdminModel.category,
                    Description = addProductAdminModel.Description,
                    price = addProductAdminModel.price,
                    Imagefilepath = imagePath
                };


                _iadminproductaddrepo.adminproductadd(dbvalu);

                return ResponseMessage.New(ResponseCode.OK, "Successfully added product.");
            }
            catch (Exception ex)
            {
                return ResponseMessage.New(ResponseCode.BadRequest, ex.Message);
            }
        }

        public List<AddproductadminDB> productget()
        {
            var getproduct = _iadminproductaddrepo.productget();
            return getproduct;
        }
    }
}
