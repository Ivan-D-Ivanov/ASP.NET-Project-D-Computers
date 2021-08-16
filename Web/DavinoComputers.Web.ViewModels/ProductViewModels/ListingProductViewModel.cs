namespace DavinoComputers.Web.ViewModels.ProductViewModels
{
    using System;
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

        public int PagesCount => (int)Math.Ceiling((double)this.ProductsCount / this.ItemsPerPage);

        public int ProductsCount { get; set; }

        public int ItemsPerPage { get; set; }

        public int PageNumber { get; init; } = 1;

        public bool HasNextPage => this.PageNumber < this.PagesCount;

        public int NextPageNumber => this.PageNumber + 1;

        public bool HasPreviusPage => this.PageNumber > 1;

        public int PreviusPageNumber => this.PageNumber - 1;
    }
}
