namespace DavinoComputers.Data.Seeding
{
    using DavinoComputers.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

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
