namespace DavinoComputers.Web.ViewModels.ProductViewModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ListingProductViewModel
    {
        [Display(Name = "Sub Categories")]
        public string SubCategory { get; set; }

        public IEnumerable<string> SubCategories { get; set; }

        public string Category { get; set; }

        public IEnumerable<string> Categories { get; set; }

        public string Brand { get; set; }

        public IEnumerable<string> Brands { get; set; }

        [Display(Name = "Search")]
        public string SearchTerm { get; set; }

        public IEnumerable<ProductInListViewModel> Products { get; set; }
    }
}
