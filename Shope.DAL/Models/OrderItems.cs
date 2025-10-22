using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shope.DAL.Models
{
    [PrimaryKey(nameof(OrderId),nameof(PrductId))]
   public class OrderItem
    {
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int PrductId { get; set; }
        public Product product { get; set; }
        public decimal totalPrice { get; set; }
    }
}
