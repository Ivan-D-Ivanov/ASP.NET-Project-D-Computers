namespace DavinoComputers.Services.HomeServices
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using DavinoComputers.Web.ViewModels.HomeViewModels;
    using DavinoComputers.Web.ViewModels.ProductViewModels;

    public interface IHomeService
    {
        List<ProductInListViewModel> ListProductsForCarousel();

        int TotalProducts();
    }
}
