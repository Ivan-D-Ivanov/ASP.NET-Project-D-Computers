namespace DavinoComputers.Services.ProductServices.Models
{
    using System.Collections.Generic;

    using DavinoComputers.Web.ViewModels.ProductViewModels;

    public class AllProductsServiceModel
    {
        public int ProductsCount { get; set; }

        public int ItemsPerPage { get; set; }

        public int PageNumber { get; set; }

        public ICollection<ProductInListViewModel> Products { get; set; }
    }
}
