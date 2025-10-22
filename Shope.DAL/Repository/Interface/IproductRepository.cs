using Shope.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shope.DAL.Repository.Interface
{
   public interface IproductRepository: IGenarecRepositry<Product>
    {
        public  Task DecreaseQuantityAsync(Dictionary<int,int>map);
    }
}
