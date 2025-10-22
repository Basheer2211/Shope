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
   public class ProductRepository: GenaricRepository<Product>,IproductRepository
    {
        private readonly ApplicationDbContext context;

        public ProductRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }
        public async Task DecreaseQuantityAsync(Dictionary<int, int> map)
        {
            foreach (var item in map)
            {
                var pro = await context.Products.FindAsync(item.Key);
                if (pro is null)
                {
                    throw new Exception("product not found");
                }
                if (pro.Quantity == 0)
                {
                    throw new Exception("out of stock");
                }
                if (item.Value > pro.Quantity)
                {
                    throw new Exception("not enough");
                }
                pro.Quantity -= item.Value;
               

            }

            await context.SaveChangesAsync();
        }
    }
}
