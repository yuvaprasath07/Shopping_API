using ShoppingEcomerceCommon.Model;
using ShoppingEcomerceCommon.Model.Viewmodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingEcommerceRepo.Interface
{
    public interface Iadminproductaddrepo
    {
        Task<bool> adminproductadd(AddproductadminDB AddproductadminModel);
        public List<AddproductadminDB> productget();
    }
}
