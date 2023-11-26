using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingEcomerceCommon.Model.Viewmodel
{
    public class RegisterShoppingVM
    {
        [Key]
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Mobilenumber { get; set; }
        public string? Email { get; set; }
        public string? password { get; set; }
        public string? Role { get; set; }


    }
}
