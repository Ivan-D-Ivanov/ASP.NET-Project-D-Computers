namespace DavinoComputers.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using DavinoComputers.Data.Models;
    using DavinoComputers.Services.ProductServices;
    using DavinoComputers.Web.ViewModels.ProductViewModels;
    using Microsoft.AspNetCore.Mvc;

    public class ProductsController : BaseController
    {
        private readonly IProductService productService;

        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }

        public IActionResult Add()
        {
            return this.View(new AddProductInputModel
            {
                SubCategories = this.productService.GetCategories(),
            });
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddProductInputModel product)
        {
            if (!this.productService.GetCategories().Any(c => c.Id == product.SubCategoryId))
            {
                this.ModelState.AddModelError(nameof(product.SubCategoryId), "This kind of category doesn't exist");
            }

            if (!this.ModelState.IsValid)
            {
                product.SubCategories = this.productService.GetCategories();
                return this.View(product);
            }

            await this.productService.CreateProduct(product);

            return this.RedirectToAction(nameof(this.All));
        }

        public IActionResult All(string searchTerm, string brand)
        {
            var productsListingViewModel = new ListingProductViewModel
            {
                Products = this.productService.ListAllProducts(searchTerm, brand),
                SearchTerm = searchTerm,
                Brands = this.productService.GetBrands(),
            };
            return this.View(productsListingViewModel);
        }

        public IActionResult Index(int id)
        {
            var product = this.productService.GetProducById(id);

            if (product == null)
            {
                return this.Redirect("/Products/All");
            }

            return this.View(product);
        }
    }
}
