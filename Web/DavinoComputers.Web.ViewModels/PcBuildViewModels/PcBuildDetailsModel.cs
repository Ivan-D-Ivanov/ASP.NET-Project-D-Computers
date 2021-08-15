namespace DavinoComputers.Web.ViewModels.PcBuildViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using DavinoComputers.Data.Models;

    public class PcBuildDetailsModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public bool IsAvailable { get; set; }

        public decimal Price { get; set; }

        public int Rate { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
