using Shope.DAL.data;
using Shope.DAL.SeedData.Interface;
using Shope.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Shope.DAL.SeedData.Class
{
    public class SeedData : ISeedData
    {
        private readonly ApplicationDbContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public SeedData(
            ApplicationDbContext Context,
            RoleManager<IdentityRole> roleManager,
            UserManager<ApplicationUser> userManager)
        {
            _context = Context;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task DataSeedAsync()
        {
            if ((await _context.Database.GetPendingMigrationsAsync()).Any())
            {
                await _context.Database.MigrateAsync();
            }

            if (!await _context.categories.AnyAsync())
            {
                await _context.categories.AddRangeAsync(
                    new Category { Name = "clothes" },
                    new Category { Name = "phone" }
                );
            }

            if (!await _context.Brands.AnyAsync())
            {
                await _context.Brands.AddRangeAsync(
                    new Brands { Name = "clothes",Image= "14713552-067b-4ede-8387-b50de91fe32a" },
                    new Brands { Name = "phone",Image = "8665dd96-6011-4e56-aa53-f4b3ee699863" },
                    new Brands { Name = "coffe", Image = "cupofcoffe" }

                );
            }

            await _context.SaveChangesAsync();
        }

        public async Task IdentityDataSeedAsync()
        {
            // إنشاء الأدوار إذا لم توجد
            if (!await _roleManager.Roles.AnyAsync())
            {
                await _roleManager.CreateAsync(new IdentityRole("admin"));
                await _roleManager.CreateAsync(new IdentityRole("Superadmin"));
                await _roleManager.CreateAsync(new IdentityRole("customer"));
            }

            if (!await _userManager.Users.AnyAsync())
            {
                var user1 = new ApplicationUser()
                {
                    UserName = "Basheer@gmail.com",
                    Email = "Basheer@gmail.com",
                    fullName = "Basheer daoud",
                    city = "AL_NoqarST",
                    street = "Default Street",
                    EmailConfirmed = true
                };

                var user2 = new ApplicationUser()
                {
                    UserName = "Ali@gmail.com",
                    Email = "Ali@gmail.com",
                    fullName = "Ali daoud",
                    city = "AL_NoqarST",
                    street = "Default Street",
                    EmailConfirmed = true
                };

                var user3 = new ApplicationUser()
                {
                    UserName = "Ahmad@gmail.com",
                    Email = "Ahmad@gmail.com",
                    fullName = "Ahmad daoud",
                    city = "AL_NoqarST",
                    street = "Default Street",
                    EmailConfirmed = true

                };

                // إنشاء المستخدمين والتحقق من نجاح العملية قبل إضافة الدور
                var result1 = await _userManager.CreateAsync(user1, " Pass@1212");
                if (result1.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user1, "admin");
                    await _userManager.AddToRoleAsync(user1, "Superadmin");
                    await _userManager.AddToRoleAsync(user1, "customer");
                }
                else
                {
                    foreach (var error in result1.Errors)
                        Console.WriteLine($"Error creating {user1.Email}: {error.Description}");
                }

                var result2 = await _userManager.CreateAsync(user2, "Pass@1212");
                if (result2.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user2, "customer");
                }
                else
                {
                    foreach (var error in result2.Errors)
                        Console.WriteLine($"Error creating {user2.Email}: {error.Description}");
                }

                var result3 = await _userManager.CreateAsync(user3, "Pass@1212");
                if (result3.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user3, "customer");
                }
                else
                {
                    foreach (var error in result3.Errors)
                        Console.WriteLine($"Error creating {user3.Email}: {error.Description}");
                }
            }

            await _context.SaveChangesAsync();
        }
    }
}
