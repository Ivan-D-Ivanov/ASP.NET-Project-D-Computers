namespace DavinoComputers.Web.ViewModels.ProductViewModels
{
    using System.Collections.Generic;

    using DavinoComputers.Data.Models;

    public class ProductDetailsViewModel
    {
        public int Id { get; set; }

        public string Model { get; set; }

        public string Brand { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public double AverageVote { get; set; }

        public string ImageUrl { get; set; }

        public bool IsAvailable { get; set; }
    }
}
