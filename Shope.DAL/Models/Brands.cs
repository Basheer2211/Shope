using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shope.DAL.Models
{
    public class Brands:BaseModel
    {
        public String Name { get; set; }
        public string Image { get; set; }
        public List<Product> products = new List<Product>();
    }
}
