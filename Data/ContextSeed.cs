using EDziennik.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDziennik.Data
{
    public static class ContextSeed
    {

        
        public static async Task SeedRolesAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Roles
            await roleManager.CreateAsync(new IdentityRole(Enums.Roles.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Enums.Roles.Teacher.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Enums.Roles.Student.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Enums.Roles.Basic.ToString()));
        }

        public static async Task SeedMark(IApplicationBuilder builder)
        {
            using (var serviceScope = builder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
                context.Database.EnsureCreated();
                if (!context.Mark.Any())
                {
                    new Mark()
                    {
                        value = 0,
                        description = "",
                        studentId = context.Users.Select(m => m.Id).First()
                    };
                    context.SaveChanges();
                }
                
            }
            
        }
        public static async Task SeedSuperAdminAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Default User
            var defaultUser = new ApplicationUser
            {
                UserName = "admin",
                Email = "admin@gmail.com",
                FirstName = "Aleksander",
                LastName = "Forusinski",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };
            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "ZAQ!2wsx");
                    await userManager.AddToRoleAsync(defaultUser, Enums.Roles.Basic.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Enums.Roles.Teacher.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Enums.Roles.Admin.ToString());
                }

            }
        }

        public static async Task SeedBasicUsersAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Default User
            var defaultStudent = new ApplicationUser
            {
                UserName = "student",
                Email = "student@gmail.com",
                FirstName = "Aleksander",
                LastName = "Forusinski",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };
            if (userManager.Users.All(u => u.Id != defaultStudent.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultStudent.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultStudent, "ZAQ!2wsx");
                    await userManager.AddToRoleAsync(defaultStudent, Enums.Roles.Basic.ToString());
                    await userManager.AddToRoleAsync(defaultStudent, Enums.Roles.Student.ToString());
                }

            }

            var defaultTeacher = new ApplicationUser
            {
                UserName = "Teacher",
                Email = "Teacher@gmail.com",
                FirstName = "Aleksander",
                LastName = "Forusinski",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };
            if (userManager.Users.All(u => u.Id != defaultTeacher.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultTeacher.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultTeacher, "ZAQ!2wsx");
                    await userManager.AddToRoleAsync(defaultTeacher, Enums.Roles.Basic.ToString());
                    await userManager.AddToRoleAsync(defaultTeacher, Enums.Roles.Teacher.ToString());
                }

            }

            var defaultBasic = new ApplicationUser
            {
                UserName = "Basic",
                Email = "Basic@gmail.com",
                FirstName = "Aleksander",
                LastName = "Forusinski",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };
            if (userManager.Users.All(u => u.Id != defaultBasic.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultBasic.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultBasic, "ZAQ!2wsx");
                    await userManager.AddToRoleAsync(defaultBasic, Enums.Roles.Basic.ToString());
                }

            }
        }
    }
}
