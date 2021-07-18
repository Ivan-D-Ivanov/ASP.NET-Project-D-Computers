namespace DavinoComputers.Services.ProductServices
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using DavinoComputers.Data.Models;
    using DavinoComputers.Web.ViewModels.ProductViewModels;

    public interface IProductService
    {
        IEnumerable<string> GetBrands();

        IEnumerable<ProductInListViewModel> ListAllProducts(string searchTerm, string brand);

        Task CreateProduct(AddProductInputModel product);

        IEnumerable<ProductSubCategoryViewModel> GetCategories();

        IndexProductViewModel GetProducById(int id);
    }
}
