using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingEcomerceCommon.Model
{
    public class Addcart
    {
        [Key]
        public int cartid { get; set; }
        public int productcartid { get; set; }
        public int userid { get; set; }

    }
}
