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

        [Authorize(Roles = Common.GlobalConstants.AdministratorRoleName)]
        public IActionResult Add()
        {
            return this.View(new AddProductFormModel
            {
                SubCategories = this.categoryService.GetSubCategories(),
            });
        }

        [Authorize(Roles = Common.GlobalConstants.AdministratorRoleName)]
        [HttpPost]
        public async Task<IActionResult> Add(AddProductFormModel product)
        {
            if (!this.categoryService.GetSubCategories().Any(c => c.Id == product.SubCategoryId))
            {
                this.ModelState.AddModelError(nameof(product.SubCategoryId), "This kind of category doesn't exist");
            }

            if (!this.ModelState.IsValid)
            {
                product.SubCategories = this.categoryService.GetSubCategories();
                return this.View(product);
            }

            await this.productService.CreateProduct(product);

            return this.RedirectToAction(nameof(this.All));
        }

        public IActionResult All(string searchTerm, string brand, string category, string subCategory)
        {
            var productsListingViewModel = new ListingProductViewModel
            {
                Products = this.productService.ListAllProducts(searchTerm, brand, category, subCategory),
                SearchTerm = searchTerm,
                Brands = this.productService.GetBrands(),
                Categories = this.categoryService.GetCategories(),
                SubCategories = this.categoryService.GetSubCategories().Select(s => s.Name),
            };
            return this.View(productsListingViewModel);
        }

        public IActionResult Details(int id)
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
