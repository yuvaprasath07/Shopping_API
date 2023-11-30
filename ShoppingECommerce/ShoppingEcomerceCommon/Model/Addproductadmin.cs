using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingEcomerceCommon.Model
{
    public class Addproductadmin
    {
        [Key]
        public int price { get; set; }
        public string? model { get; set; }
        public string? Description { get; set; }
        public int category { get; set; }
        public IFormFile Imagefilepath { get; set; }
    }

    public class AddproductadminDB
    {
        [Key]
        public int productId { get; set; }
        public int price { get; set; }
        public string? model { get; set; }
        public string? Description { get; set; }
        public int category { get; set; }
        public string Imagefilepath { get; set; }
    }
}
