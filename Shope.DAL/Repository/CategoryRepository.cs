using Shope.DAL.data;
using Shope.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shope.DAL.Repository
{
    
   public class CategoryRepository: Irepository
    {
        private readonly ApplicationDbContext context;
        public CategoryRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public int Add(Category category)
        {
            context.categories.Add(category);
          return  context.SaveChanges();
        }

        public int Delete(Category category)
        {
            context.Remove(category);
          return  context.SaveChanges();
        }

        public IEnumerable<Category> GetallCategory()
        {
            var categories = context.categories.ToList();
            return categories;
        }

        public Category GetbyId(int id)
        {
            return context.categories.Find(id);
        }





        public int Update(Category category)
        {
            context.Update(category);
            return context.SaveChanges(); 
        }
    }
}
