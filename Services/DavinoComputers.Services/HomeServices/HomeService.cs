namespace DavinoComputers.Services.HomeServices
{
    using System.Collections.Generic;
    using System.Linq;

    using DavinoComputers.Data.Common.Repositories;
    using DavinoComputers.Data.Models;
    using DavinoComputers.Web.ViewModels.ProductViewModels;

    public class HomeService : IHomeService
    {
        private readonly IDeletableEntityRepository<Product> productsRepository;


        public HomeService(IDeletableEntityRepository<Product> productsRepository)
        {
            this.productsRepository = productsRepository;
        }

        public int TotalProducts()
        {
            var allProducts = this.productsRepository.AllAsNoTracking().Count();
            return allProducts;
        }

        public List<ProductInListViewModel> ListProductsForCarousel()
        {
            var lastThreeProducts = this.productsRepository.AllAsNoTracking()
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
