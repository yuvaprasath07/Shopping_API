using ShoppingEcomerceCommon.Model.Viewmodel;
using ShoppingEcomerceCommon.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingEcommerceRepo.Interface
{
    public interface Icategroyrepo
    {
        public Dictionary<int, string> categroylookup();
    }
}
