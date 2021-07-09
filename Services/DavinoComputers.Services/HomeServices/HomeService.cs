namespace DavinoComputers.Services.HomeServices
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using DavinoComputers.Data.Common.Models;
    using DavinoComputers.Data.Common.Repositories;
    using DavinoComputers.Data.Models;
    using DavinoComputers.Web.ViewModels.HomeViewModels;

    public class HomeService : IHomeService
    {
        private readonly IDeletableEntityRepository<Category> categoryRepository;
        private readonly IDeletableEntityRepository<SubCategory> subCategoryRepository;
        private readonly IDeletableEntityRepository<Image> imageRepository;
        private readonly IRepository<Comment> commentsRepository;
        private readonly IDeletableEntityRepository<Product> productsRepository;


        public HomeService(
            IDeletableEntityRepository<Category> categoryRepository,
            IRepository<Comment> commentsRepository,
            IDeletableEntityRepository<Product> productsRepository,
            IDeletableEntityRepository<Image> imageRepository,
            IDeletableEntityRepository<SubCategory> subCategoryRepository)
        {
            this.categoryRepository = categoryRepository;
            this.commentsRepository = commentsRepository;
            this.productsRepository = productsRepository;
            this.imageRepository = imageRepository;
            this.subCategoryRepository = subCategoryRepository;
        }

        public HomeViewModel GetCounts()
        {
            var allCounts = new HomeViewModel
            {
                CategoriesCounts = this.categoryRepository.AllAsNoTracking().Count(),
                SubCategoriesCounts = this.subCategoryRepository.AllAsNoTracking().Count(),
                CommentsCounts = this.commentsRepository.AllAsNoTracking().Count(),
                ImagesCounts = this.imageRepository.AllAsNoTracking().Count(),
                ProductsCounts = this.productsRepository.AllAsNoTracking().Count(),
            };
            return allCounts;
        }
    }
}
