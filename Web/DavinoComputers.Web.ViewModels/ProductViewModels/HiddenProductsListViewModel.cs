namespace DavinoComputers.Web.ViewModels.ProductViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class HiddenProductsListViewModel : ProductInListViewModel
    {
        public string DeletedOn { get; set; }
    }
}
