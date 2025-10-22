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
    public class OrderItemRepository : IOrderItemRepository
    {
        public OrderItemRepository(ApplicationDbContext applicationDbContext)
        {
            ApplicationDbContext = applicationDbContext;
        }

        private readonly ApplicationDbContext ApplicationDbContext;

        public async Task AddAsync(List<OrderItem> orderItems)
        {
            await ApplicationDbContext.AddRangeAsync(orderItems);
            await ApplicationDbContext.SaveChangesAsync();
        }
    }
}
