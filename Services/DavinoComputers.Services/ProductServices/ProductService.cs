namespace DavinoComputers.Services.ProductServices
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DavinoComputers.Data.Common.Repositories;
    using DavinoComputers.Data.Models;
    using DavinoComputers.Web.ViewModels.ProductViewModels;

    public class ProductService : IProductService
    {
        private readonly IDeletableEntityRepository<Product> productsRepository;
        private readonly IDeletableEntityRepository<SubCategory> subCategory;
        private readonly IDeletableEntityRepository<Category> categories;

        public ProductService(IDeletableEntityRepository<Product> productsRepository, IDeletableEntityRepository<SubCategory> subCategory, IDeletableEntityRepository<Category> categories)
        {
            this.productsRepository = productsRepository;
            this.subCategory = subCategory;
            this.categories = categories;
        }

        public IEnumerable<string> GetBrands()
        {
            return this.productsRepository.AllAsNoTracking()
                .Select(p => p.Brand)
                .Distinct()
                .ToList();
        }

        public async Task CreateProduct(AddProductInputModel product)
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

            await this.productsRepository.AddAsync(newProduct);
            await this.productsRepository.SaveChangesAsync();
        }

        public IndexProductViewModel GetProducById(int id)
        {
            var product = this.productsRepository.All().FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return null;
            }

            return new IndexProductViewModel
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
            var productQuery = this.productsRepository.AllAsNoTracking();

            if (!string.IsNullOrWhiteSpace(category))
            {
                var categoryId = this.categories.All().FirstOrDefault(c => c.Name == category);
                if (categoryId != null)
                {
                    productQuery = productQuery.Where(p => p.SubCategory.CategoryId == categoryId.Id);
                }
            }

            if (!string.IsNullOrWhiteSpace(subCategory))
            {
                var subCategoryId = this.subCategory.All().FirstOrDefault(c => c.Name == subCategory);
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
