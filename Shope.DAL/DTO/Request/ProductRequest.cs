using Microsoft.AspNetCore.Http;
using Shope.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shope.DAL.DTO.Request
{
   public class ProductRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public int Quantity { get; set; }
        public IFormFile NameImage { get; set; }
        public double Rate { get; set; }
        public int CategoryId { get; set; }
        public int? BrandsId { get; set; }
    }
}
