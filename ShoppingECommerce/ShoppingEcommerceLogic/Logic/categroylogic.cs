using ShoppingEcommerceLogic.InterFace;
using ShoppingEcommerceRepo.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingEcommerceLogic.Logic
{
    public class categroylogic : Icategroylogic
    {
        public readonly Icategroyrepo _Categroyrepo;
        public categroylogic(Icategroyrepo Categroyrepo)
        {
            _Categroyrepo = Categroyrepo;
        }
        public List<Dictionary<string, object>> categroylookup()
        {
            var lookupdata = _Categroyrepo.categroylookup();
            return lookupdata;
        }
    }
}
