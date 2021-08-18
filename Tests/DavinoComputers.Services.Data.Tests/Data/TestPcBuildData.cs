namespace DavinoComputers.Services.Data.Tests.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using DavinoComputers.Data.Models;

    using static DavinoComputers.Services.Data.Tests.Data.TestProductData;

    public static class TestPcBuildData
    {
        public static IEnumerable<PcBuild> PcBuildsData
            => Enumerable.Range(0, 3).Select(i => new PcBuild()
            {
                Products = new List<Product>()
                {
                    new Product { SubCategoryId = 1 },
                    new Product { SubCategoryId = 2 },
                    new Product { SubCategoryId = 3 },
                    new Product { SubCategoryId = 4 },
                    new Product { SubCategoryId = 5 },
                    new Product { SubCategoryId = 6 },
                },
            });
    }
}
