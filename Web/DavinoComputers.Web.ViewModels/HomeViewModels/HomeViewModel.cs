namespace DavinoComputers.Web.ViewModels.HomeViewModels
{
    using System.Collections.Generic;

    using DavinoComputers.Web.ViewModels.ProductViewModels;

    public class HomeViewModel
    {
        public int ProductsCounts { get; set; }

        public List<ProductInListViewModel> CarouselProducts { get; set; }
    }
}
