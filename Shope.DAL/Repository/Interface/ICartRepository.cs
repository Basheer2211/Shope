using Shope.DAL.DTO.Request;
using Shope.DAL.DTO.Response;
using Shope.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shope.DAL.Repository.Interface
{
   public interface ICartRepository
    {
        public int add(Cart request);
        public List<Cart> GetUserCart(String userId);
        Task<bool> ClearCart(string userId);
    }
}
