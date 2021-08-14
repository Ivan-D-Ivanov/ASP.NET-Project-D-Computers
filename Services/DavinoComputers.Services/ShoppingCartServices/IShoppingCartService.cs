namespace DavinoComputers.Services.ShoppingCartServices
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using DavinoComputers.Web.ViewModels.ShoppingCartViewModels;

    public interface IShoppingCartService
    {
        ShoppingCartViewModel GetMyShoppingCartProducts(string username);

        string AddProduct(string username, int productId);

        string AddPcBuild(string username, int pcbuildId);

        string DeleteProductFromCart(string username, int productId);

        string DeletePcBuildFromCart(string username, int productId);

        void EditProductQuantity(string username, int productId, int quantity);
    }
}
