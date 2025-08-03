using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shope.DAL.Models;

namespace Shope.DAL.data
{
   public class ApplicationDbContext:DbContext
    {
        public DbSet<Category> categories { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        
    }
}
