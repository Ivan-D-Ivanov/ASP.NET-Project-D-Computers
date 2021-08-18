namespace DavinoComputers.Services.Data.Tests.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using DavinoComputers.Data.Models;
    using DavinoComputers.Web.ViewModels.ProductViewModels;

    public static class TestProductData
    {
        public static IEnumerable<Product> GetTenProducts
            => Enumerable.Range(0, 10).Select(i => new Product { });

        public static AddProductFormModel ProductFormModel
            => new AddProductFormModel
            {
                SubCategoryId = 1,
                Model = "3600x",
                Brand = "ryzen",
                ImageUrl = null,
                Description = "aaljhfjlsdhgljdahlgadfljdahfljahdlj",
                IsAvailable = true,
                Price = 123,
            };
    }
}
