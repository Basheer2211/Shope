using Shope.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shope.DAL.Repository.Interface
{
   public interface IorderRepository
    {
        Task<Order> getUserById(int OrderId);
        Task<Order> addasync(Order order);
    }
}
