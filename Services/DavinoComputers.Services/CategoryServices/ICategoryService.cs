namespace DavinoComputers.Services.CategoryServices
{
    using System.Collections.Generic;

    using DavinoComputers.Web.ViewModels.ProductViewModels;

    public interface ICategoryService
    {
        IEnumerable<ProductSubCategoryViewModel> GetSubCategories();

        IEnumerable<string> GetCategories();
    }
}
