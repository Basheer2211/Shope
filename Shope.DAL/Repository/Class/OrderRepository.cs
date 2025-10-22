using Microsoft.EntityFrameworkCore;
using Shope.DAL.data;
using Shope.DAL.Models;
using Shope.DAL.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shope.DAL.Repository.Class
{
   public class OrderRepository : IorderRepository
    {
        public OrderRepository(ApplicationDbContext context)
        {
            Context = context;
        }

        private readonly ApplicationDbContext Context;

        public async Task<Order> getUserById(int OrderId)
        {
            
            return await Context.orders.Include(c=>c.User).FirstOrDefaultAsync(c=>c.id== OrderId);
        }

        public async Task<Order> addasync(Order order)
        {
           await Context.orders.AddAsync(order);
            await Context.SaveChangesAsync();
            return order;
        }
    }
}
