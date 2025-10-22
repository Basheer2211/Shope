using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shope.DAL.Models
{
    public enum OrderStatus
    {
        pending=1,
        canceld=2,
        Approved=3,
        Shipped=4,
        Deliverd=5
    }
    public enum PaymentMethode
    {
        cash,
        visa
    }

   public class Order
    {
        //order
        public int id { get; set; }
        public OrderStatus status { get; set; } = OrderStatus.pending;
        public DateTime OrderTime = DateTime.Now;
        public DateTime ShippedTime { get; set; }
        public decimal TotalAmount { get; set; }

        //payment

        public PaymentMethode paymentMethode { get; set; } = PaymentMethode.visa;
        public string? PaymentId { get; set; }
        //carrier شركه توصيل
        public string? CarrierId { get; set; }
        public string? TrackingNumber { get; set; }
        //relation
        public string UserId { get; set; }  
        public ApplicationUser User { get; set; }

    }
}
