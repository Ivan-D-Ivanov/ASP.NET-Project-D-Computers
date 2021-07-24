namespace DavinoComputers.Services.ProductServices
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DavinoComputers.Web.ViewModels.ProductViewModels;

    public interface IProductService
    {
        IEnumerable<ProductInListViewModel> ListAllProducts(string searchTerm, string brand, string category, string subCategory);

        Task CreateProduct(AddProductInputModel product);

        IEnumerable<string> GetBrands();

        IndexProductViewModel GetProducById(int id);
    }
}
