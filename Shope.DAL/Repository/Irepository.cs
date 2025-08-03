using Shope.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shope.DAL.Repository
{
    public  interface Irepository
    {
        Category GetbyId(int id);
        IEnumerable<Category> GetallCategory();
        int Add(Category category);
        int Update(Category category);
        int Delete(Category category);

    }
}
