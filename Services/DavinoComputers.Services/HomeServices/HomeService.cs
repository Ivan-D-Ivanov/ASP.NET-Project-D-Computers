namespace DavinoComputers.Services.HomeServices
{
    using System.Collections.Generic;
    using System.Linq;

    using DavinoComputers.Data;
    using DavinoComputers.Web.ViewModels.ProductViewModels;

    public class HomeService : IHomeService
    {
        private readonly ApplicationDbContext data;

        public HomeService(ApplicationDbContext data)
        {
            this.data = data;
        }

        public int TotalProducts()
        {
            var allProducts = this.data.Products.AsQueryable().Count();
            return allProducts;
        }

        public List<ProductInListViewModel> ListProductsForCarousel()
        {
            var lastThreeProducts = this.data.Products.AsQueryable()
                .OrderByDescending(p => p)
                .Take(3)
                .Select(p => new ProductInListViewModel
                {
                    Id = p.Id,
                    Model = p.Model,
                    Brand = p.Brand,
                    IsAvailable = p.IsAvailable,
                    Description = p.Description,
                    ImageUrl = p.ImageUrl,
                    Rate = p.Rate,
                    Price = p.Price,
                    CategoryName = p.SubCategory.Name,
                })
                .ToList();

            return lastThreeProducts;
        }
    }
}
