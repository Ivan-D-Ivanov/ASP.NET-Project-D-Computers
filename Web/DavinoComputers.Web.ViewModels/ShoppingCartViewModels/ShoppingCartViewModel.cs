namespace DavinoComputers.Web.ViewModels.ShoppingCartViewModels
{
    using System.Collections.Generic;

    using DavinoComputers.Web.ViewModels.PcBuildViewModels;
    using DavinoComputers.Web.ViewModels.ProductViewModels;

    public class ShoppingCartViewModel
    {
        public string ApplicationUsername { get; set; }

        public ICollection<ShoppingCartProductViewModel> Products { get; set; }

        public ICollection<ShoppingCartPcBuildViewModel> PcBuilds { get; set; }
    }
}
