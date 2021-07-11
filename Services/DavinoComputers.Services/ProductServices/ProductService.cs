namespace DavinoComputers.Services.ProductServices
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using DavinoComputers.Data.Common.Repositories;
    using DavinoComputers.Data.Models;
    using DavinoComputers.Web.ViewModels.ProductViewModels;

    public class ProductService : IProductService
    {
        private readonly IDeletableEntityRepository<Product> productsRepository;
        private readonly IDeletableEntityRepository<SubCategory> subCategory;

        public ProductService(IDeletableEntityRepository<Product> productsRepository, IDeletableEntityRepository<SubCategory> subCategory)
        {
            this.productsRepository = productsRepository;
            this.subCategory = subCategory;
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

        public IEnumerable<ProductSubCategoryViewModel> GetCategories()
        {
            return this.subCategory.All().Select(c => new ProductSubCategoryViewModel
            {
                Id = c.Id,
                Name = c.Name,
            });
        }
    }
}
