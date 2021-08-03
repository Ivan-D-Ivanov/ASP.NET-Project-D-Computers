namespace DavinoComputers.Services.HomeServices
{
    using System.Collections.Generic;

    using DavinoComputers.Web.ViewModels.ProductViewModels;

    public interface IHomeService
    {
        List<ProductInListViewModel> ListProductsForCarousel();

        int TotalProducts();
    }
}
