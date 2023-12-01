using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingEcomerceCommon.Model
{
    public class cartGet
    {
        [Key]
        public int productId { get; set; }
        public int registerid { get; set; }
        public string? Name { get; set; }
        public int price { get; set; }
        public string? model { get; set; }
        public string? Description { get; set; }
        public string? Imagefilepath { get; set; }
    }
}
