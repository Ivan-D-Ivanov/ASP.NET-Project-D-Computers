namespace DavinoComputers.Services.Data.Tests.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using DavinoComputers.Data.Models;

    public static class TestVoteData
    {
        private static byte voting = 1;

        public static IEnumerable<Vote> GetVotes
            => Enumerable.Range(0, 4).Select(v => new Vote
            {
                Value = voting++,
            });
    }
}
