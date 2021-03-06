namespace DavinoComputers.Services.ProductServices
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DavinoComputers.Data;
    using DavinoComputers.Data.Models;
    using DavinoComputers.Services.CategoryServices;
    using DavinoComputers.Services.ProductServices.Models;
    using DavinoComputers.Web.ViewModels.ProductViewModels;
    using Microsoft.EntityFrameworkCore;

    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext data;
        private readonly ICategoryService categoryService;

        public ProductService(ApplicationDbContext data, ICategoryService categoryService)
        {
            this.data = data;
            this.categoryService = categoryService;
        }

        public int GetCount()
        {
            return this.data.Products.Count();
        }

        public IEnumerable<string> GetBrands()
        {
            return this.data.Products.AsQueryable()
                .Select(p => p.Brand)
                .Distinct()
                .ToList();
        }

        public async Task CreateProduct(AddProductFormModel product)
        {
            var newProduct = new Product
            {
                Model = product.Model,
                Brand = product.Brand,
                Description = product.Description,
                Price = product.Price,
                IsAvailable = product.IsAvailable,
                ImageUrl = product.ImageUrl,
                SubCategoryId = product.SubCategoryId,
            };

            await this.data.Products.AddAsync(newProduct);
            await this.data.SaveChangesAsync();
        }

        public bool EditProduct(int id, AddProductFormModel product)
        {
            var dataProduct = this.data.Products.FirstOrDefault(p => p.Id == id);
            if (dataProduct == null)
            {
                return false;
            }

            dataProduct.Model = product.Model;
            dataProduct.Brand = product.Brand;
            dataProduct.Description = product.Description;
            dataProduct.Price = product.Price;
            dataProduct.IsAvailable = product.IsAvailable;
            dataProduct.ImageUrl = product.ImageUrl;
            dataProduct.SubCategoryId = product.SubCategoryId;

            this.data.SaveChanges();
            return true;
        }

        public AddProductFormModel GetProducForm(int id)
        {
            var product = this.data.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return null;
            }

            return new AddProductFormModel
            {
                Model = product.Model,
                Brand = product.Brand,
                Description = product.Description,
                IsAvailable = product.IsAvailable,
                Price = product.Price,
                ImageUrl = product.ImageUrl,
                SubCategoryId = product.SubCategoryId,
                SubCategories = this.categoryService.GetSubCategories(),
            };
        }

        public ProductDetailsViewModel GetProducDetails(int id)
        {
            var product = this.data.Products.Include(x => x.Votes).FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return null;
            }

            return new ProductDetailsViewModel
            {
                Id = product.Id,
                Model = product.Model,
                Brand = product.Brand,
                Description = product.Description,
                IsAvailable = product.IsAvailable,
                AverageVote = product.Votes.Count() > 0 ? product.Votes.Average(v => v.Value) : 1,
                Price = product.Price,
                ImageUrl = product.ImageUrl,
            };
        }

        public AllProductsServiceModel ListAllProducts(
            string searchTerm = null,
            string brand = null,
            string category = null,
            string subCategory = null,
            int currentPage = 1,
            int itemsPerPage = int.MaxValue)
        {
            var productQuery = this.data.Products.AsQueryable().Where(p => p.IsDeleted == false);

            if (!string.IsNullOrWhiteSpace(category))
            {
                var categoryId = this.data.Categories.FirstOrDefault(c => c.Name == category);
                if (categoryId != null)
                {
                    productQuery = productQuery.Where(p => p.SubCategory.CategoryId == categoryId.Id);
                }
            }

            if (!string.IsNullOrWhiteSpace(subCategory))
            {
                var subCategoryId = this.data.SubCategories.FirstOrDefault(c => c.Name == subCategory);
                if (subCategoryId != null)
                {
                    productQuery = productQuery.Where(p => p.SubCategory.Id == subCategoryId.Id);
                }
            }

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                productQuery = productQuery.Where(p =>
                (p.Brand + " " + p.Model).ToLower().Contains(searchTerm.ToLower()));
            }

            if (!string.IsNullOrWhiteSpace(brand))
            {
                productQuery = productQuery.Where(p => p.Brand == brand);
            }

            var totalProduct = productQuery.Count();

            var products = productQuery
                .OrderByDescending(p => p.CreatedOn)
                .Skip((currentPage - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .Select(p => new ProductInListViewModel
                {
                    Id = p.Id,
                    Model = p.Model,
                    Brand = p.Brand,
                    Description = p.Description,
                    Price = p.Price,
                    ImageUrl = p.ImageUrl,
                    IsAvailable = p.IsAvailable,
                    CategoryName = p.SubCategory.Name,
                })
                .ToList();

            return new AllProductsServiceModel
            {
                ProductsCount = totalProduct,
                PageNumber = currentPage,
                ItemsPerPage = itemsPerPage,
                Products = products,
            };
        }

        // ToDO
        public ICollection<HiddenProductsListViewModel> GetDeletedProducts()
        {
            var deletedProducts = this.data.Products
                .AsQueryable()
                .Include(p => p.SubCategory)
                .Where(p => p.IsDeleted == true)
                .Select(p => new HiddenProductsListViewModel
                {
                    Id = p.Id,
                    Brand = p.Brand,
                    Model = p.Model,
                    Description = p.Description,
                    Price = p.Price,
                    ImageUrl = p.ImageUrl,
                    IsAvailable = p.IsAvailable,
                    DeletedOn = p.DeletedOn.ToString(),
                    CategoryName = p.SubCategory.Name,
                }).ToList();

            if (deletedProducts.Count <= 0)
            {
                return null;
            }

            return deletedProducts;
        }
    }
}
