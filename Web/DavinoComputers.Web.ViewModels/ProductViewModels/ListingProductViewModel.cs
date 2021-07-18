namespace DavinoComputers.Web.ViewModels.ProductViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class ListingProductViewModel
    {
        public string Brand { get; set; }

        public IEnumerable<string> Brands { get; set; }

        [Display(Name = "Search")]
        public string SearchTerm { get; set; }

        public Sorting Sort { get; set; }

        public IEnumerable<ProductInListViewModel> Products { get; set; }
    }
}
