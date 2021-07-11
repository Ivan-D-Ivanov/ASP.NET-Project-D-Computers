namespace DavinoComputers.Data.Seeding
{
    using DavinoComputers.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class SubCategorySeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.SubCategories.Any())
            {
                return;
            }

            await dbContext.SubCategories.AddAsync(new SubCategory { Name = "Mother Boards", CategoryId = 5 });
            await dbContext.SubCategories.AddAsync(new SubCategory { Name = "CPU", CategoryId = 5 });
            await dbContext.SubCategories.AddAsync(new SubCategory { Name = "GPU", CategoryId = 5 });
            await dbContext.SubCategories.AddAsync(new SubCategory { Name = "RAM", CategoryId = 5 });
            await dbContext.SubCategories.AddAsync(new SubCategory { Name = "Cooler Supply", CategoryId = 5 });
            await dbContext.SubCategories.AddAsync(new SubCategory { Name = "HDD", CategoryId = 5 });
            await dbContext.SubCategories.AddAsync(new SubCategory { Name = "SSD", CategoryId = 5 });
            await dbContext.SubCategories.AddAsync(new SubCategory { Name = "Computer Cases", CategoryId = 5 });
            await dbContext.SubCategories.AddAsync(new SubCategory { Name = "Mouses", CategoryId = 6 });
            await dbContext.SubCategories.AddAsync(new SubCategory { Name = "Keyboards", CategoryId = 6 });
            await dbContext.SubCategories.AddAsync(new SubCategory { Name = "HeadSet", CategoryId = 6 });
            await dbContext.SubCategories.AddAsync(new SubCategory { Name = "Mouse Pads", CategoryId = 6 });

            await dbContext.SaveChangesAsync();
        }
    }
}
