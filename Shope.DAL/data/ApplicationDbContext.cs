using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Shope.DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Shope.DAL.data
{
   public class ApplicationDbContext: IdentityDbContext<ApplicationUser>
    {
        public DbSet<Category> categories { get; set; }
        public DbSet<Brands> Brands { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<OrderItem> orderItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);//عشان يجيب ال dbset الموجوده في IdentityDbContext
            builder.Entity<ApplicationUser>().ToTable("User");//هيك منغير اسم الجدول
            builder.Entity<IdentityRole>().ToTable("Rles");
            builder.Entity<IdentityUserRole<String>>().ToTable("UserRoles");
            builder.Ignore<IdentityUserToken<string>>();
            builder.Ignore<IdentityUserLogin<string>>();
            builder.Ignore<IdentityUserClaim<string>>();
            builder.Ignore<IdentityRoleClaim<string>>();
        }

    }
}
