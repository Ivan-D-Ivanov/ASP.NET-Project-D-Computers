namespace DavinoComputers.Services.ShoppingCartServices
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using DavinoComputers.Data;
    using DavinoComputers.Web.ViewModels.PcBuildViewModels;
    using DavinoComputers.Web.ViewModels.ProductViewModels;
    using DavinoComputers.Web.ViewModels.ShoppingCartViewModels;
    using Microsoft.EntityFrameworkCore;

    public class ShoppingCartService : IShoppingCartService
    {
        private readonly ApplicationDbContext data;

        public ShoppingCartService(ApplicationDbContext data)
        {
            this.data = data;
        }

        public string AddPcBuild(string username, int pcbuildId)
        {
            var shoppingCart = this.data.ShoppingCart
                .Include(p => p.Products)
                .Include(pc => pc.PcBuilds)
                .FirstOrDefault(sh => sh.ApplicationUser.UserName == username);
            if (shoppingCart == null)
            {
                return null;
            }

            var pcbuild = this.data.PcBuilds.FirstOrDefault(p => p.Id == pcbuildId);
            if (pcbuild == null)
            {
                return null;
            }

            if (shoppingCart.PcBuilds.Contains(pcbuild))
            {
                return "Cant duplicate products";
            }

            shoppingCart.PcBuilds.Add(pcbuild);
            this.data.ShoppingCart.Update(shoppingCart);
            this.data.SaveChanges();
            return "Success";
        }

        public string AddProduct(string username, int productId)
        {
            var shoppingCart = this.data.ShoppingCart
                .Include(p => p.Products)
                .Include(pc => pc.PcBuilds)
                .FirstOrDefault(sh => sh.ApplicationUser.UserName == username);
            if (shoppingCart == null)
            {
                return null;
            }

            var product = this.data.Products.FirstOrDefault(p => p.Id == productId);
            if (product == null)
            {
                return null;
            }

            if (shoppingCart.Products.Contains(product))
            {
                return "Cant duplicate products";
            }

            shoppingCart.Products.Add(product);
            this.data.ShoppingCart.Update(shoppingCart);
            this.data.SaveChanges();
            return "Success";
        }

        public void EditProductQuantity(string username, int productId, int quantity)
        {
        }

        public string DeleteProductFromCart(string username, int productId)
        {
            var shoppingCart = this.data.ShoppingCart
                .Include(sh => sh.ApplicationUser)
                .Include(sh => sh.Products)
                .FirstOrDefault(sh => sh.ApplicationUser.UserName == username);

            if (shoppingCart == null)
            {
                return null;
            }

            var product = this.data.Products.FirstOrDefault(p => p.Id == productId);
            shoppingCart.Products.Remove(product);
            this.data.ShoppingCart.Update(shoppingCart);
            this.data.SaveChanges();
            return "Success";
        }

        public string DeletePcBuildFromCart(string username, int pcbuildId)
        {
            var shoppingCart = this.data.ShoppingCart
                .Include(sh => sh.ApplicationUser)
                .Include(sh => sh.PcBuilds)
                .FirstOrDefault(sh => sh.ApplicationUser.UserName == username);

            if (shoppingCart == null)
            {
                return null;
            }

            var pcbuild = this.data.PcBuilds.FirstOrDefault(p => p.Id == pcbuildId);
            shoppingCart.PcBuilds.Remove(pcbuild);
            this.data.ShoppingCart.Update(shoppingCart);
            this.data.SaveChanges();
            return "Success";
        }

        public ShoppingCartViewModel GetMyShoppingCartProducts(string username)
        {
            if (username == null)
            {
                return null;
            }

            var productsInShoppingCart = this.data.ShoppingCart
                .Include(x => x.ApplicationUser)
                .Include(x => x.Products)
                .Include(x => x.PcBuilds)
                .Where(sh => sh.ApplicationUser.UserName == username)
                .Select(sh => new ShoppingCartViewModel
                {
                    ApplicationUsername = username,
                    Products = sh.Products.Select(p => new ShoppingCartProductViewModel
                    {
                        Id = p.Id,
                        Model = p.Model,
                        Brand = p.Brand,
                        Price = p.Price,
                        ImageUrl = p.ImageUrl,
                        Quantity = 1,
                    })
                    .ToList(),
                    PcBuilds = sh.PcBuilds.Select(pc => new ShoppingCartPcBuildViewModel
                    {
                        Id = pc.Id,
                        Name = pc.Name,
                        Price = pc.Price,
                        ImageUrl = pc.ImageUrl,
                        Quantity = 1,
                    }).ToList(),
                })
                .FirstOrDefault();

            if (productsInShoppingCart == null)
            {
                return null;
            }

            return productsInShoppingCart;
        }
    }
}
