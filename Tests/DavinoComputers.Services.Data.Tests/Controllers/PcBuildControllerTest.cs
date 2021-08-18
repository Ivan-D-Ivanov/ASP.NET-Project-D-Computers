namespace DavinoComputers.Services.Data.Tests.Controllers
{

    using DavinoComputers.Services.CategoryServices;
    using DavinoComputers.Services.PcBuildsServices;
    using DavinoComputers.Services.ProductServices;
    using DavinoComputers.Web.Controllers;
    using DavinoComputers.Web.ViewModels.PcBuildViewModels;
    using MyTested.AspNetCore.Mvc;
    using Xunit;

    using static DavinoComputers.Services.Data.Tests.Data.TestPcBuildData;
    using static DavinoComputers.Services.Data.Tests.Data.OneWholePcBuildCorrectFormData;
    using static DavinoComputers.Services.Data.Tests.Data.TestSubCategoriesData;
    using static System.Net.WebRequestMethods;

    public class PcBuildControllerTest
    {
        [Theory]
        [InlineData(1)]
        public void PcBuildDetailsShouldReturnViewModelAndCountOfProduct(int id)
            => MyController<PcBuildsController>
            .Instance(controller => controller
                .WithDependencies(From.Services<IPcBuildService>())
                .WithDependencies(From.Services<ICategoryService>())
                .WithDependencies(From.Services<IProductService>())
                .WithData(PcBuildsData)
                .WithUser(u => u.InRole("Administrator")))
            .Calling(c => c.Details(id))
            .ShouldReturn()
            .View(v => v
                .WithModelOfType<PcBuildDetailsModel>()
            .Passing(p => p.Products.Count == 6
                        && p.Id == 1));

        [Fact]
        public void PcBuildDetailsShouldThrowNotFoundIfThereIsNoSuchId()
            => MyController<PcBuildsController>
            .Instance(controller => controller
                .WithDependencies(From.Services<IPcBuildService>())
                .WithDependencies(From.Services<ICategoryService>())
                .WithDependencies(From.Services<IProductService>())
                .WithData(PcBuildsData)
                .WithUser(u => u.InRole("Administrator")))
            .Calling(c => c.Details(int.MaxValue))
            .ShouldReturn()
            .NotFound();

        [Fact]
        public void AllPcbuildShouldReturnViewResultAndShouldReturnCorrectCount()
            => MyController<PcBuildsController>
                .Instance(controller => controller
                    .WithDependencies(From.Services<IPcBuildService>())
                    .WithDependencies(From.Services<ICategoryService>())
                    .WithDependencies(From.Services<IProductService>())
                    .WithData(PcBuildsData)
                    .WithUser(u => u.InRole("Administrator")))
                .Calling(c => c.All())
            .ShouldReturn()
            .View(v => v
                .WithModelOfType<ListingPcBuildsViewModel>()
                .Passing(p => p.PcBuilds.Count == 3));

        [Fact]
        public void GetPcBuildAddActionShoudReturnCorrectViewModelwithViewResult()
            => MyController<PcBuildsController>
            .Instance(controller => controller
                    .WithDependencies(From.Services<IPcBuildService>())
                    .WithDependencies(From.Services<ICategoryService>())
                    .WithDependencies(From.Services<IProductService>())
                    .WithData(PcBuildsData)
                    .WithUser(u => u.InRole("Administrator")))
            .Calling(c => c.Add())
            .ShouldHave()
            .ActionAttributes(att => att.RestrictingForAuthorizedRequests())
            .AndAlso()
            .ShouldReturn()
            .View(v => v
                .WithModelOfType<AddPcBuildFormModel>());

        [Fact]
        public void PostPcBuildAddActionShouldReturnViewResultIfModelStateIsInvalid()
            => MyController<PcBuildsController>
            .Instance(controller => controller
                    .WithDependencies(From.Services<IPcBuildService>())
                    .WithDependencies(From.Services<ICategoryService>())
                    .WithDependencies(From.Services<IProductService>())
                    .WithData(PcBuildsData)
                    .WithUser(u => u.InRole("Administrator")))
            .Calling(c => c.Add(new AddPcBuildFormModel()))
            .ShouldHave()
            .ActionAttributes(att => att
                    .RestrictingForAuthorizedRequests()
                    .RestrictingForHttpMethod(Http.Post))
            .AndAlso()
            .ShouldReturn()
            .View(v => v
                .WithModelOfType<AddPcBuildFormModel>());

        [Fact]
        public void PostPcBuildAddActionShouldRedirectToHomePage()
            => MyController<PcBuildsController>
            .Instance(controller => controller
                    .WithDependencies(From.Services<IPcBuildService>())
                    .WithDependencies(From.Services<ICategoryService>())
                    .WithDependencies(From.Services<IProductService>())
                    .WithData(FakeSubCategories)
                    .WithData(PcBuildsData)
                    .WithUser(u => u.InRole("Administrator")))
            .Calling(c => c.Add(FakeAddPcBuildForm))
            .ShouldHave()
            .ActionAttributes(att => att
                    .RestrictingForAuthorizedRequests()
                    .RestrictingForHttpMethod(Http.Post))
            .AndAlso()
            .ShouldReturn()
            .Redirect("/");

        [Theory]
        [InlineData(1)]
        public void GetPcbuildEditActionShouldReturnViewResultWithCorrectModel(int id)
            => MyController<PcBuildsController>
            .Instance(controller => controller
                    .WithDependencies(From.Services<IPcBuildService>())
                    .WithDependencies(From.Services<ICategoryService>())
                    .WithDependencies(From.Services<IProductService>())
                    .WithData(PcBuildsData)
                    .WithData(FakeSubCategories)
                    .WithUser(u => u.InRole("Administrator")))
            .Calling(c => c.Edit(id))
            .ShouldHave()
            .ActionAttributes(att => att
                .RestrictingForAuthorizedRequests())
            .AndAlso()
            .ShouldReturn()
            .View(v => v.WithModelOfType<AddPcBuildFormModel>());

        [Fact]
        public void PostPcBuildEditActionShouldReturnRedirectToActionIfSuccess()
            => MyController<PcBuildsController>
            .Instance(controller => controller
                    .WithDependencies(From.Services<IPcBuildService>())
                    .WithDependencies(From.Services<ICategoryService>())
                    .WithDependencies(From.Services<IProductService>())
                    .WithData(PcBuildsData)
                    .WithData(FakeSubCategories)
                    .WithUser(u => u.InRole("Administrator")))
            .Calling(c => c.Edit(1, FakeAddPcBuildForm))
            .ShouldHave()
            .ActionAttributes(att => att
                .RestrictingForAuthorizedRequests()
                .RestrictingForHttpMethod(Http.Post))
            .AndAlso()
            .ShouldReturn()
            .RedirectToAction("All");
    }
}
