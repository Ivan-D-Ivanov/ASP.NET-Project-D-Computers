namespace DavinoComputers.Services.Data.Tests.Controllers
{
    using DavinoComputers.Services.CategoryServices;
    using DavinoComputers.Services.ProductServices;
    using DavinoComputers.Web.Controllers;
    using DavinoComputers.Web.ViewModels.ProductViewModels;
    using MyTested.AspNetCore.Mvc;
    using Xunit;

    using static DavinoComputers.Services.Data.Tests.Data.TestProductData;

    public class ProductControllerTests
    {
        [Theory]
        [InlineData(1)]
        public void DetailsActionShoudReturnViewWithCorrectViewModel(int id)
            => MyController<ProductsController>
            .Instance(controller => controller
                .WithDependencies(From.Services<IProductService>())
                .WithDependencies(From.Services<ICategoryService>())
                .WithData(GetTenProducts)
                .WithUser(user => user.InRoles("Administrator")))
            .Calling(c => c.Details(id))
            .ShouldReturn()
            .View(v => v.WithModelOfType<ProductDetailsViewModel>()
            .Passing(p => p.Id == id));

        [Fact]
        public void AllActionShoudReturnTheCorrectAmountOfProduct()
            => MyController<ProductsController>
            .Instance(controller => controller
                    .WithDependencies(From.Services<IProductService>())
                    .WithDependencies(From.Services<ICategoryService>())
                    .WithData(GetTenProducts))
            .Calling(c => c.All(new ListingProductViewModel()))
            .ShouldReturn()
            .View(view => view
            .WithModelOfType<ListingProductViewModel>()
            .Passing(model =>
                model.ProductsCount == 10));
    }
}
