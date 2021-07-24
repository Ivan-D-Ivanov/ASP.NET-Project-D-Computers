namespace DavinoComputers.Services.CategoryServices
{
    using System.Collections.Generic;
    using System.Linq;

    using DavinoComputers.Data.Common.Repositories;
    using DavinoComputers.Data.Models;
    using DavinoComputers.Web.ViewModels.ProductViewModels;

    public class CategoryService : ICategoryService
    {
        private readonly IDeletableEntityRepository<Category> categories;
        private readonly IDeletableEntityRepository<SubCategory> subCategory;

        public CategoryService(
            IDeletableEntityRepository<SubCategory> subCategory,
            IDeletableEntityRepository<Category> categories)
        {
            this.subCategory = subCategory;
            this.categories = categories;
        }

        public IEnumerable<ProductSubCategoryViewModel> GetSubCategories()
        {
            return this.subCategory.All().Select(c => new ProductSubCategoryViewModel
            {
                Id = c.Id,
                Name = c.Name,
            });
        }

        public IEnumerable<string> GetCategories()
        {
            return this.categories.AllAsNoTracking().Select(c => c.Name).ToList();
        }
    }
}
