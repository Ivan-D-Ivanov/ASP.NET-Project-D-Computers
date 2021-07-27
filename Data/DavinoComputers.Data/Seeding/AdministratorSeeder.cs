namespace DavinoComputers.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using DavinoComputers.Data.Models;
    using Microsoft.AspNetCore.Identity;

    using Microsoft.Extensions.DependencyInjection;

    using static DavinoComputers.Common.GlobalConstants;

    public class AdministratorSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Users.Any(u => u.Roles.Count > 0))
            {
                return;
            }

            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            var user = new ApplicationUser { UserName = "adminDavino@admin.com", Email = "adminDavino@admin.com", EmailConfirmed = true, PhoneNumber = "0896666666" };

            await userManager.CreateAsync(user, "davinoi");

            await userManager.AddToRoleAsync(user, AdministratorRoleName);
        }
    }
}
