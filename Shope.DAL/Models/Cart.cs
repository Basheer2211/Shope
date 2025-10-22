using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shope.DAL.Models
{
    [PrimaryKey(nameof(ProductId),nameof(UserId))]
   public class Cart
    {
        public int ProductId { get; set; }
        public Product product { get; set; }    
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public int count { get; set; }
    }
}
