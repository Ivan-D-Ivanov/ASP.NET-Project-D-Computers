namespace DavinoComputers.Services.VotesServices
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using DavinoComputers.Data;
    using DavinoComputers.Data.Models;

    public class VoteService : IVoteService
    {
        private readonly ApplicationDbContext data;

        public VoteService(ApplicationDbContext data)
        {
            this.data = data;
        }

        public async Task SetVoteAsync(int productId, string userId, byte value)
        {
            var vote = this.data.Votes.FirstOrDefault(v => v.ProductId == productId && v.UserId == userId);

            if (vote == null)
            {
                vote = new Vote
                {
                    ProductId = productId,
                    UserId = userId,
                };

                await this.data.Votes.AddAsync(vote);
            }

            vote.Value = value;
            await this.data.SaveChangesAsync();
        }

        public double GetAverageVotes(int productId)
        {
            return this.data.Votes.Where(v => v.ProductId == productId).Average(x => x.Value);
        }
    }
}
