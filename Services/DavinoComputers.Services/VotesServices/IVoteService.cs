namespace DavinoComputers.Services.VotesServices
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IVoteService
    {
        Task SetVoteAsync(int productId, string userId, byte value);

        double GetAverageVotes(int productId);
    }
}
