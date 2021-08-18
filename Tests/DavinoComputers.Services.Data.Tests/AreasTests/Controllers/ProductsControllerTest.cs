namespace DavinoComputers.Web.Areas.Administration.Controllers
{
    using System.Linq;

    using DavinoComputers.Data.Models;
    using DavinoComputers.Services.CategoryServices;
    using DavinoComputers.Services.ProductServices;
    using DavinoComputers.Web.ViewModels.ProductViewModels;
    using MyTested.AspNetCore.Mvc;
    using Xunit;

    using static System.Net.WebRequestMethods;

    using static DavinoComputers.Services.Data.Tests.Data.TestProductData;

    public class ProductsControllerTest
    {
        [Fact]
        public void GetProductCreateActionShoudRedirectToPostAction()
            => MyController<ProductsController>
            .Instance(controller => controller
                .WithUser(u => u.InRole("Administrator")))
            .Calling(c => c.Create())
            .ShouldReturn()
            .View(view => view.WithModelOfType<AddProductFormModel>());

        [Theory]
        [InlineData("3600", "ryzen 5")]
        public void PostProductCreateActionShoudRedirectoToAllAndSaveTheProducta(string model, string brand)
           => MyController<ProductsController>
            .Instance(controller => controller
            .WithUser(user => user.InRole("Administrator")))
            .Calling(c => c.Create(new AddProductFormModel
            {
            }))
            .ShouldHave()
            .ActionAttributes(a => a
                .RestrictingForHttpMethod(Http.Post))
            .AndAlso()
            .ShouldReturn()
            .View(v => v.WithModelOfType<AddProductFormModel>());

        [Theory]
        [InlineData(1)]
        public void GetEditActionShoudReturnViewModel(int id)
            => MyController<ProductsController>
            .Instance(controller => controller
            .WithData(GetTenProducts)
                .WithUser(user => user.InRole("Administrator")))
            .Calling(c => c.Edit(id))
            .ShouldReturn()
            .View(v => v
                .WithModelOfType<AddProductFormModel>());

    }
}
