namespace DavinoComputers.Services.CategoryServices
{
    using System.Collections.Generic;
    using System.Linq;

    using DavinoComputers.Data;
    using DavinoComputers.Web.ViewModels.ProductViewModels;

    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext data;

        public CategoryService(ApplicationDbContext data)
        {
            this.data = data;
        }

        public IEnumerable<ProductSubCategoryViewModel> GetSubCategories()
        {
            return this.data.SubCategories.AsQueryable().Select(c => new ProductSubCategoryViewModel
            {
                Id = c.Id,
                Name = c.Name,
            });
        }

        public IEnumerable<string> GetCategories()
        {
            return this.data.Categories.AsQueryable().Where(c => c.Name != "PcBuilds").Select(c => c.Name).ToList();
        }
    }
}
