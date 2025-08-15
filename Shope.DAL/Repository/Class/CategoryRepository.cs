using Shope.DAL.data;
using Shope.DAL.Models;
using Shope.DAL.Repository.Class;
using Shope.DAL.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shope.DAL.Repository
{
    
   public class CategoryRepository:  GenaricRepository<Category>, Irepository
    {
        private readonly ApplicationDbContext context;
           
        public CategoryRepository(ApplicationDbContext context): base(context)
        {
            this.context = context;
        }

  
    }
}
