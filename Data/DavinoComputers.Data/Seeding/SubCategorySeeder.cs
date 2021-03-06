namespace DavinoComputers.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using DavinoComputers.Data.Models;

    public class SubCategorySeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.SubCategories.Any())
            {
                return;
            }

            await dbContext.SubCategories.AddAsync(new SubCategory { Name = "Mother Boards", CategoryId = 4 });
            await dbContext.SubCategories.AddAsync(new SubCategory { Name = "CPU", CategoryId = 4 });
            await dbContext.SubCategories.AddAsync(new SubCategory { Name = "GPU", CategoryId = 4 });
            await dbContext.SubCategories.AddAsync(new SubCategory { Name = "RAM", CategoryId = 4 });
            await dbContext.SubCategories.AddAsync(new SubCategory { Name = "Cooler Supply", CategoryId = 4 });
            await dbContext.SubCategories.AddAsync(new SubCategory { Name = "HDD", CategoryId = 4 });
            await dbContext.SubCategories.AddAsync(new SubCategory { Name = "SSD", CategoryId = 4 });
            await dbContext.SubCategories.AddAsync(new SubCategory { Name = "Computer Cases", CategoryId = 4 });
            await dbContext.SubCategories.AddAsync(new SubCategory { Name = "Mouses", CategoryId = 5 });
            await dbContext.SubCategories.AddAsync(new SubCategory { Name = "Keyboards", CategoryId = 5 });
            await dbContext.SubCategories.AddAsync(new SubCategory { Name = "HeadSet", CategoryId = 5 });
            await dbContext.SubCategories.AddAsync(new SubCategory { Name = "Mouse Pads", CategoryId = 5 });

            await dbContext.SaveChangesAsync();
        }
    }
}
