namespace DavinoComputers.Services.ProductServices
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DavinoComputers.Data;
    using DavinoComputers.Data.Models;
    using DavinoComputers.Web.ViewModels.ProductViewModels;

    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext data;

        public ProductService(ApplicationDbContext data)
        {
            this.data = data;
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

        public ProductDetailsViewModel GetProducById(int id)
        {
            var product = this.data.Products.FirstOrDefault(p => p.Id == id);

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
                Rate = product.Rate,
                Price = product.Price,
                ImageUrl = product.ImageUrl,
            };
        }

        public IEnumerable<ProductInListViewModel> ListAllProducts(string searchTerm, string brand, string category, string subCategory)
        {
            var productQuery = this.data.Products.AsQueryable();

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

            var products = productQuery
                .OrderByDescending(p => p.CreatedOn)
                .Select(p => new ProductInListViewModel
                {
                    Id = p.Id,
                    Model = p.Model,
                    Brand = p.Brand,
                    Description = p.Description,
                    Rate = p.Rate,
                    Price = p.Price,
                    ImageUrl = p.ImageUrl,
                    IsAvailable = p.IsAvailable,
                    CategoryName = p.SubCategory.Name,
                })
                .ToList();

            return products;
        }
    }
}
