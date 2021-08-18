namespace DavinoComputers.Services.Data.Tests.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using DavinoComputers.Services.HomeServices;
    using DavinoComputers.Web.Controllers;
    using DavinoComputers.Web.ViewModels;
    using DavinoComputers.Web.ViewModels.HomeViewModels;
    using Microsoft.AspNetCore.Mvc;
    using MyTested.AspNetCore.Mvc;
    using Xunit;

    using static DavinoComputers.Services.Data.Tests.Data.TestProductData;

    public class HomeControllerTests
    {
        [Fact]
        public void PrivacyShoudReturnViewResult()
            => MyController<HomeController>
            .Instance()
            .Calling(v => v.Privacy())
            .ShouldReturn()
            .View();

        [Fact]
        public void ErrorShoudReutnErroeViewModel()
            => MyController<HomeController>
            .Instance()
            .Calling(c => c.Error())
            .ShouldReturn()
            .View(v => v.WithModelOfType<ErrorViewModel>());

        [Fact]
        public void IndexShoudReturnCorrectViewModel()
         => MyController<HomeController>
            .Instance(controller => controller
                .WithDependencies(From.Services<IHomeService>())
                .WithData(GetTenProducts))
            .Calling(c => c.Index())
            .ShouldReturn()
            .View(view => view.WithModelOfType<HomeViewModel>()
            .Passing(model => model.ProductsCounts == 10));
    }
}
