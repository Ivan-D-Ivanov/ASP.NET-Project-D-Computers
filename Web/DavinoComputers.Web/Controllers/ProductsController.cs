namespace DavinoComputers.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using DavinoComputers.Web.ViewModels.ProductViewModels;
    using Microsoft.AspNetCore.Mvc;

    public class ProductsController : Controller
    {

        public IActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Add(AddProductInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            return this.Redirect("/");
        }
    }
}
