﻿namespace DavinoComputers.Services.ProductServices
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DavinoComputers.Web.ViewModels.ProductViewModels;

    public interface IProductService
    {
        IEnumerable<ProductInListViewModel> ListAllProducts(string searchTerm, string brand, string category, string subCategory);

        Task CreateProduct(AddProductFormModel product);

        IEnumerable<string> GetBrands();

        ProductDetailsViewModel GetProducDetails(int id);

        AddProductFormModel GetProducForm(int id);

        bool EditProduct(int id, AddProductFormModel product);
    }
}
