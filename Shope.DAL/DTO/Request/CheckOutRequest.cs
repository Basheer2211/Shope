using Shope.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shope.DAL.DTO.Request
{
   public class CheckOutRequest
    {
        public PaymentMethode paymentmethode { get; set; }
    }
}
