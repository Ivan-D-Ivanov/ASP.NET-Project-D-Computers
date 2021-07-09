namespace DavinoComputers.Web.ViewModels.ProductViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class AddProductInputModel
    {
        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        public decimal Price { get; set; }

        [Required]
        [MinLength(2)]
        public string Brand { get; set; }

        public bool IsAvailable { get; set; }

        public string SubCategoryId { get; set; }

        [Url]
        public string ImageUrl { get; set; }
    }
}
