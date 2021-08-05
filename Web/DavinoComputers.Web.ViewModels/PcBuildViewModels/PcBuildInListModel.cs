namespace DavinoComputers.Web.ViewModels.PcBuildViewModels
{
    using System.Collections.Generic;

    using DavinoComputers.Web.ViewModels.ProductViewModels;

    public class PcBuildInListModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public bool IsAvailable { get; set; }

        public int Rate { get; set; }

        public decimal Price { get; set; }

        public IEnumerable<ProductInListViewModel> Products { get; set; }
    }
}
