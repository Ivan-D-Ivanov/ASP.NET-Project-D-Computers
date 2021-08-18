namespace DavinoComputers.Services.Data.Tests.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using DavinoComputers.Data.Models;

    public static class TestSubCategoriesData
    {
        public static IEnumerable<SubCategory> FakeSubCategories
         => new List<SubCategory>()
         {
             new SubCategory { Name = "CPU", Id = 1 },
             new SubCategory { Name = "GPU", Id = 2 },
             new SubCategory { Name = "RAM", Id = 3 },
             new SubCategory { Name = "Mother Boards", Id = 4 },
             new SubCategory { Name = "Power Supply", Id = 5 },
             new SubCategory { Name = "Computer Cases", Id = 6 },
         };
    }
}
