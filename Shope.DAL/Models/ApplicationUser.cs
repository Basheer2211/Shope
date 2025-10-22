using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Shope.DAL.Models
{
    public class ApplicationUser:IdentityUser//هيك مناخذ كل اشي موجود بالايدنتيتي و منضيف الاشياء الي بدنا اياها عليهم
    {
        public string fullName { get; set; }
        public string? city { get; set; }
        public string? street { get; set; }
        public string? codeResetPassword { get; set; }
        public DateTime ExpiryCode { get; set; }
    }
}
