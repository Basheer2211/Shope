using Microsoft.EntityFrameworkCore;
using Shope.DAL.data;
using Shope.DAL.DTO.Request;
using Shope.DAL.DTO.Response;
using Shope.DAL.Models;
using Shope.DAL.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shope.DAL.Repository.Class
{
    public class cartRepository : ICartRepository
    {
        public cartRepository(ApplicationDbContext context)
        {
            Context = context;
        }

        private readonly ApplicationDbContext Context;

        public int add(Cart request)
        {
            Context.Carts.Add(request);
            return Context.SaveChanges();
        }

        public List<Cart> GetUserCart(string userId)
        {
            return Context.Carts.Include(c => c.product).Where(c => c.UserId == userId).ToList();
        }

        public async Task<bool> ClearCart(string userId)
        {
            var items = Context.Carts.Where(c => c.UserId == userId).ToList();
             Context.Carts.RemoveRange(items);
            await Context.SaveChangesAsync();
            return true;
            
        }
    }
}
