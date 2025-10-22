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
    public class GenaricRepository<T>:IGenarecRepositry<T> where T:BaseModel
    {
        private readonly ApplicationDbContext context;

        public GenaricRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public int Add(T category)
        {
            context.Add(category);
            return context.SaveChanges();
        }

       

        public int Delete(T category)
        {
            context.Set<T>().Remove(category);
            return context.SaveChanges();
        }

       

        public IEnumerable<T> GetallEntity()
        {
            
            var categories = context.Set<T>().ToList();
            return categories;
        }

       

        public T GetbyId(int id)
        {
            return context.Set<T>().Find(id);
        }

        public int Update(T category)
        {
            context.Update(category);
            return context.SaveChanges();
        }

       

       
    }
}
