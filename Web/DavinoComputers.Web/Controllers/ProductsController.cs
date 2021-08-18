namespace DavinoComputers.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using DavinoComputers.Services.CategoryServices;
    using DavinoComputers.Services.ProductServices;
    using DavinoComputers.Web.ViewModels.ProductViewModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class ProductsController : BaseController
    {
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;

        public ProductsController(IProductService productService, ICategoryService categoryService)
        {
            this.productService = productService;
            this.categoryService = categoryService;
        }

        public IActionResult All(ListingProductViewModel query)
        {
            const int itemsPerPage = 9;
            var productsResult = this.productService.ListAllProducts(query.SearchTerm, query.Brand, query.Category, query.SubCategory, query.PageNumber, itemsPerPage);

            query.ItemsPerPage = itemsPerPage;
            query.Products = productsResult.Products;
            query.ProductsCount = productsResult.ProductsCount;
            query.Brands = this.productService.GetBrands();
            query.Categories = this.categoryService.GetCategories();
            query.SubCategories = this.categoryService.GetSubCategories().Select(s => s.Name);
            return this.View(query);
        }

        public IActionResult Details(int id)
        {
            var product = this.productService.GetProducDetails(id);

            if (product == null)
            {
                return this.Redirect("/Products/All");
            }

            return this.View(product);
        }
    }
}
