namespace DavinoComputers.Web.Controllers
{
    using DavinoComputers.Services.ShoppingCartServices;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using static DavinoComputers.Web.WebConstants;

    [Authorize]
    public class ShoppingCartsController : BaseController
    {
        private readonly IShoppingCartService shoppingCartService;

        public ShoppingCartsController(IShoppingCartService shoppingCartService)
        {
            this.shoppingCartService = shoppingCartService;
        }

        public IActionResult Index()
        {
            var username = this.User.Identity.Name;
            var shoppingCart = this.shoppingCartService.GetMyShoppingCartProducts(username);
            if (shoppingCart == null)
            {
                return this.NotFound();
            }

            return this.View(shoppingCart);
        }

        public IActionResult AddProductToCart(int productId, string name)
        {
            var username = this.User.Identity.Name;
            var result = this.shoppingCartService.AddProduct(username, productId);
            if (result == "Cart doesnt exist" || result == null)
            {
                return this.NotFound();
            }

            if (result == "Cant duplicate products")
            {
                return this.Redirect(this.Request.Headers["Referer"].ToString());
            }

            this.TempData[GlobalMessageKey] = $"{name} have been added successfully!";
            return this.Redirect(this.Request.Headers["Referer"].ToString());
        }

        public IActionResult AddPcBuildToCart(int pcbuildId, string name)
        {
            var username = this.User.Identity.Name;
            var result = this.shoppingCartService.AddPcBuild(username, pcbuildId);
            if (result == "Cart doesnt exist" || result == null)
            {
                return this.NotFound();
            }

            if (result == "Cant duplicate products")
            {
                return this.Redirect(this.Request.Headers["Referer"].ToString());
            }

            this.TempData[GlobalMessageKey] = $"{name} have been added successfully!";

            return this.Redirect(this.Request.Headers["Referer"].ToString());
        }

        public IActionResult EditProduct(int productId, int quantity)
        {
            var username = this.User.Identity.Name;
            this.shoppingCartService.EditProductQuantity(username, productId, quantity);
            return this.RedirectToAction(nameof(this.Index));
        }

        public IActionResult DeleteProduct(int productId)
        {
            var username = this.User.Identity.Name;
            var result = this.shoppingCartService.DeleteProductFromCart(username, productId);
            if (result == null)
            {
                return this.NotFound();
            }

            return this.Redirect(this.Request.Headers["Referer"].ToString());
        }

        public IActionResult DeletePcBuild(int pcbuildId)
        {
            var username = this.User.Identity.Name;
            var result = this.shoppingCartService.DeletePcBuildFromCart(username, pcbuildId);
            if (result == null)
            {
                return this.NotFound();
            }

            return this.Redirect(this.Request.Headers["Referer"].ToString());
        }
    }
}
