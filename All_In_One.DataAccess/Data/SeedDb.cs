using All_In_One.DataAccess.Data;
using All_In_One.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace All_In_One.DataAccess
{
    public class SeedDb
    {




        public static async Task InitializeDbAsync(IServiceProvider services)
        {
            var context = services.GetRequiredService<ApplicationDbContext>();
            EnsereDbMigrationAndUpdate(context);

            //var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
            //await EnsureRolesAsync(roleManager);

            var userManager = services.GetRequiredService<UserManager<IdentityUser>>();
            await EnsureTestAdminAsync(userManager, context);
        }

        private static async Task EnsureTestAdminAsync(UserManager<IdentityUser> userManager, ApplicationDbContext context)
        {
            var studernt = context.Students.Where(x => x.StudentName == "Mr X").FirstOrDefault();

            if (studernt == null)
            {
                Student x = new()
                {
                    StudentName = "Mr X",
                    StudentMail = "abc@gmail.com",
                    DepartmentId = 1,
                };

                context.Students.Add(x);
                context.SaveChanges();
            }


        }

        //private static async Task EnsureRolesAsync(RoleManager<IdentityRole> roleManager)
        //{
        //    if (!await roleManager.RoleExistsAsync(SD.Role_Admin))
        //    {
        //        await roleManager.CreateAsync(new IdentityRole(SD.Role_Admin));
        //    }
        //    if (!await roleManager.RoleExistsAsync(SD.Role_MasterReseller))
        //    {
        //        await roleManager.CreateAsync(new IdentityRole(SD.Role_MasterReseller));
        //    }
        //    if (!await roleManager.RoleExistsAsync(SD.Role_Reseller))
        //    {
        //        await roleManager.CreateAsync(new IdentityRole(SD.Role_Reseller));
        //    }
        //    if (!await roleManager.RoleExistsAsync(SD.Role_Client))
        //    {
        //        await roleManager.CreateAsync(new IdentityRole(SD.Role_Client));
        //    }
        //    if (!await roleManager.RoleExistsAsync(SD.Role_PaymentMaker))
        //    {
        //        await roleManager.CreateAsync(new IdentityRole(SD.Role_PaymentMaker));
        //    }

        //}

        private static void EnsereDbMigrationAndUpdate(ApplicationDbContext context)
        {
            //context.Database.EnsureCreated();
            context.Database.Migrate();
        }
    }
}

