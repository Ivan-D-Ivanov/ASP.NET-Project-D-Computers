namespace DavinoComputers.Web.ViewModels.ProductViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using DavinoComputers.Data.Models;

    public class IndexProductViewModel
    {
        public IndexProductViewModel()
        {
            this.Comments = new HashSet<Comment>();
        }

        public int Id { get; set; }

        public string Model { get; set; }

        public string Brand { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int Rate { get; set; }

        public string ImageUrl { get; set; }

        public bool IsAvailable { get; set; }

        public IEnumerable<Comment> Comments { get; set; }
    }
}
