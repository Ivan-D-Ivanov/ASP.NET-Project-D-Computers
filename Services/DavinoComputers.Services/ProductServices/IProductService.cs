namespace DavinoComputers.Services.ProductServices
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DavinoComputers.Services.ProductServices.Models;
    using DavinoComputers.Web.ViewModels.ProductViewModels;

    public interface IProductService
    {
        AllProductsServiceModel ListAllProducts(string searchTerm, string brand, string category, string subCategory, int currentPage, int itemsPerPage);

        Task CreateProduct(AddProductFormModel product);

        IEnumerable<string> GetBrands();

        ProductDetailsViewModel GetProducDetails(int id);

        AddProductFormModel GetProducForm(int id);

        bool EditProduct(int id, AddProductFormModel product);

        ICollection<HiddenProductsListViewModel> GetDeletedProducts();

        int GetCount();
    }
}
