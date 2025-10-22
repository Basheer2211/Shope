using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shope.DAL.Models
{
   public class Product:BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public int Quantity { get; set; }
        public string NameImage { get; set; }
        public double Rate { get; set; }
        public int CategoryId { get; set; }
        public Category category { get;set; }   
        public int? BrandsId { get; set; }
        public Brands? brands { get; set; }
    }
}
