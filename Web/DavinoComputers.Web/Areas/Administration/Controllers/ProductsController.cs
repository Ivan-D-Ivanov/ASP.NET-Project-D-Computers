namespace DavinoComputers.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using DavinoComputers.Data;
    using DavinoComputers.Services.CategoryServices;
    using DavinoComputers.Services.ProductServices;
    using DavinoComputers.Web.ViewModels.ProductViewModels;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    [Area("Administration")]
    public class ProductsController : AdministrationController
    {
        private readonly ApplicationDbContext context;
        private readonly ICategoryService categoryService;
        private readonly IProductService productService;

        public ProductsController(ApplicationDbContext context, ICategoryService categoryService, IProductService productService)
        {
            this.context = context;
            this.categoryService = categoryService;
            this.productService = productService;
        }

        // GET: Administration/Products
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = this.context.Products.Include(p => p.SubCategory);
            return this.View(await applicationDbContext.ToListAsync());
        }

        // GET: Administration/Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var product = await this.context.Products
                .Include(p => p.SubCategory)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return this.NotFound();
            }

            return this.View(product);
        }

        // GET: Administration/Products/Create
        public IActionResult Create()
        {
            return this.View(new AddProductFormModel
            {
                SubCategories = this.categoryService.GetSubCategories(),
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddProductFormModel product)
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

            return this.Redirect("/Products/All");
        }

        // GET: Administration/Products/Edit/5
        public IActionResult Edit(int id)
        {
            var product = this.productService.GetProducForm(id);
            if (product == null)
            {
                return this.NotFound();
            }

            return this.View(product);
        }

        // POST: Administration/Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public IActionResult Edit(int id, AddProductFormModel product)
        {
            var isEdited = this.productService.EditProduct(id, product);
            if (isEdited == false)
            {
                return this.NotFound();
            }

            return this.RedirectToAction(nameof(this.Index));
        }

        // GET: Administration/Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var product = await this.context.Products
                .Include(p => p.SubCategory)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return this.NotFound();
            }

            return this.View(product);
        }

        // POST: Administration/Products/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await this.context.Products.FindAsync(id);
            product.IsDeleted = true;
            await this.context.SaveChangesAsync();
            return this.RedirectToAction(nameof(this.Index));
        }

        private bool ProductExists(int id)
        {
            return this.context.Products.Any(e => e.Id == id);
        }
    }
}
