using Shope.DAL.DTO.Request;
using Shope.DAL.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shope.BLL.Services.Interfaces
{
   public interface ICartServices
    {
        public bool AddTocart(CartRequest request, string userId);
        public cartSymmaryResponse Getcart(string userId);
        public Task<bool> ClearCartAsync(string userId);
    }
}
