using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingEcomerceCommon.Model
{
    public class LoginModel
    {
        public string EmailId { get; set; }
        public string Password { get; set; }
    }
    public class UserModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public int Id { get; set; }


    }
}
