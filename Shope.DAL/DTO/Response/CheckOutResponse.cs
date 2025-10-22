using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shope.DAL.DTO.Response
{
   public class CheckOutResponse
    {
        public bool success { get; set; }
        public string message { get; set; }
        public string? url { get; set; }
        public string? paymentId { get; set; }
    }
}
