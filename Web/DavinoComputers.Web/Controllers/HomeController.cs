namespace DavinoComputers.Web.Controllers
{
    using System.Diagnostics;

    using DavinoComputers.Services.HomeServices;
    using DavinoComputers.Web.ViewModels;
    using DavinoComputers.Web.ViewModels.HomeViewModels;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseController
    {
        private readonly IHomeService homeService;

        public HomeController(IHomeService homeService)
        {
            this.homeService = homeService;
        }

        public IActionResult Index()
        {
            var totalProducts = this.homeService.TotalProducts();
            var lastThree = this.homeService.ListProductsForCarousel();
            return this.View(new HomeViewModel
            {
                ProductsCounts = totalProducts,
                CarouselProducts = lastThree,
            });
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
