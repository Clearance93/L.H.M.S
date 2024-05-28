using ClinicalApp.Data;
using ClinicalApp.Interface;
using ClinicalApp.Models;
using ClinicalApp.Utility;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ClinicalApp.Repository
{
    public class DbInitializer : IDbInitializer
    {
        private readonly DatabaseContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbInitializer(DatabaseContext context,
                             UserManager<ApplicationUser> userManager,
                             RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task Initializer()
        {
            try
            {
                if ((await _context.Database.GetPendingMigrationsAsync()).Any())
                {
                    await _context.Database.MigrateAsync();
                }
            }
            catch (Exception ex)
            {
                // Handle the exception as needed
            }

            if (!(await _roleManager.RoleExistsAsync(Workers.AdminRole)))
            {
                await _roleManager.CreateAsync(new IdentityRole(Workers.AdminRole));
                await _roleManager.CreateAsync(new IdentityRole(Workers.ManagerRole));
                await _roleManager.CreateAsync(new IdentityRole(Workers.DoctorRole));
                await _roleManager.CreateAsync(new IdentityRole(Workers.ITRole));
                await _roleManager.CreateAsync(new IdentityRole(Workers.ParamedicRole));
                await _roleManager.CreateAsync(new IdentityRole(Workers.CleanerRole));
                await _roleManager.CreateAsync(new IdentityRole(Workers.FinanceRole));
                await _roleManager.CreateAsync(new IdentityRole(Workers.HRRole));
                await _roleManager.CreateAsync(new IdentityRole(Workers.NurseRole));
                await _roleManager.CreateAsync(new IdentityRole(Workers.PorterRole));

                var user = new ApplicationUser
                {
                    UserName = "clearancemorumudi@gmail.com",
                    Email = "clearancemorumudi@gmail.com",
                    EmailConfirmed = true,
                    FirstName = "Clearance",
                    LastName = "Morumudi",
                    StreetName = "1331 Edward Avenue",
                    Surbub = "Phomolong",
                    City_Town = "Choorokop",
                    ZipCode = "1624",
                    Image = "https://lh3.googleusercontent.com/a/ACg8ocIJTdrG3pIn6kjOoORUvYNAprVyu5pPSq7Bp-j7qmzwkc8NXS8ueQ=s288-c-no",
                };

                var result = await _userManager.CreateAsync(user, "1!Clearmorumudi");

                if (result.Succeeded)
                {
                    user = await _context.ApplicationUsers.FirstOrDefaultAsync(d => d.Email == "clearancemorumudi@gmail.com");
                    await _userManager.AddToRoleAsync(user, Workers.ManagerRole);
                }
            }

            return;
        }
    }
}
