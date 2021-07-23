namespace DavinoComputers.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using DavinoComputers.Data.Models;

    public class CategorySeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Categories.Any())
            {
                return;
            }

            await dbContext.Categories.AddAsync(new Category { Name = "Hardware"});
            await dbContext.Categories.AddAsync(new Category { Name = "Accessories" });
            await dbContext.Categories.AddAsync(new Category { Name = "PcBuilds" });

            await dbContext.SaveChangesAsync();
        }
    }
}
