namespace DavinoComputers.Services.Data.Tests.Controllers
{
    using System.Linq;

    using DavinoComputers.Data.Models;
    using DavinoComputers.Services.VotesServices;
    using DavinoComputers.Web.Controllers;
    using DavinoComputers.Web.ViewModels.VoteViewModels;
    using MyTested.AspNetCore.Mvc;
    using Xunit;

    using static System.Net.WebRequestMethods;

    using static DavinoComputers.Services.Data.Tests.Data.TestProductData;

    public class VoteControllersTests
    {
        [Theory]
        [InlineData(1, 4)]
        public void PostShoudWorkWihtTheCorrectModelAndHaveAverageValue(int productId, byte value)
            => MyController<VotesController>
            .Instance(controller => controller
                .WithDependencies(From.Services<IVoteService>())
                .WithData(GetTenProducts)
                .WithUser())
            .Calling(c => c.Post(new PostVoteInputModel
            {
                ProductId = productId,
                Value = value,
            }))
            .ShouldHave()
            .ActionAttributes(a => a
            .RestrictingForHttpMethod(Http.Post)
            .RestrictingForAuthorizedRequests())
            .Data(data => data
            .WithSet<Vote>(s => s.Any(
                v => v.ProductId == productId &&
                v.Value == value &&
                v.UserId == TestUser.Identifier)
            ))
            .AndAlso()
            .ShouldReturn()
            .Object();
    }
}
