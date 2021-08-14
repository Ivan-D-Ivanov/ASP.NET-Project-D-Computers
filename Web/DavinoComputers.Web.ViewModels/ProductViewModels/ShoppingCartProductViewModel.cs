namespace DavinoComputers.Web.ViewModels.ProductViewModels
{
    public class ShoppingCartProductViewModel
    {
        public int Id { get; set; }

        public string Model { get; set; }

        public string Brand { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public string ImageUrl { get; set; }
    }
}
