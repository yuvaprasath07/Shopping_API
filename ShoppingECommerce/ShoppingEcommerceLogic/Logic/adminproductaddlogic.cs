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
                string username = addProductAdminModel.model;
                string userFolderPath = Path.Combine("wwwroot", "ProductImages");

                if (!Directory.Exists(userFolderPath))
                {
                    Directory.CreateDirectory(userFolderPath);
                }

                string uniqueFileName = $"{username}_{Guid.NewGuid()}{Path.GetExtension(addProductAdminModel.Imagefilepath)}";

                string imagePath = Path.Combine(userFolderPath, uniqueFileName);

                byte[] imageBytes = await File.ReadAllBytesAsync(addProductAdminModel.Imagefilepath);

                await File.WriteAllBytesAsync(imagePath, imageBytes);

                addProductAdminModel.Imagefilepath = imagePath;

                _iadminproductaddrepo.adminproductadd(addProductAdminModel);

                return ResponseMessage.New(ResponseCode.OK, "Successfully Add");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving image: {ex.Message}");

                return ResponseMessage.New(ResponseCode.BadRequest, ex.Message);
            }
        }

       
    }
}
