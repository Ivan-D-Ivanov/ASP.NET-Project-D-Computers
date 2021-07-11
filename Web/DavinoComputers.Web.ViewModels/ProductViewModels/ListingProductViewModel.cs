namespace DavinoComputers.Web.ViewModels.ProductViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class ListingProductViewModel
    {
        public IEnumerable<ProductInListViewModel> Products { get; set; }

        public int Page { get; set; }
    }
}
