namespace DavinoComputers.Services.ProductServices
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using DavinoComputers.Web.ViewModels.ProductViewModels;

    public interface IProductService
    {
        Task CreateProduct(AddProductInputModel product);

        IEnumerable<ProductSubCategoryViewModel> GetCategories();
    }
}
