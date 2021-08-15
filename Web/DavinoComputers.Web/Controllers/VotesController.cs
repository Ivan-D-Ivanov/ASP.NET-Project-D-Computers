namespace DavinoComputers.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using DavinoComputers.Services.VotesServices;
    using DavinoComputers.Web.ViewModels.VoteViewModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/[controller]/[action]")]
    public class VotesController : BaseController
    {
        private readonly IVoteService voteService;

        public VotesController(IVoteService voteService)
        {
            this.voteService = voteService;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<PostVoteResponseModel>> Post(PostVoteInputModel input)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            await this.voteService.SetVoteAsync(input.ProductId, userId, input.Value);
            var averageVote = this.voteService.GetAverageVotes(input.ProductId);
            return new PostVoteResponseModel { AverageVote = averageVote };
        }
    }
}
