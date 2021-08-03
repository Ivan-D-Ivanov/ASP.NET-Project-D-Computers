namespace DavinoComputers.Web.ViewModels.ProductViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DavinoComputers.Common.GlobalConstants;

    public class AddProductInputModel
    {
        [Required]
        [StringLength(MaxProductModelLength, MinimumLength = MinProductModelLength)]
        public string Model { get; set; }

        [Required]
        [StringLength(MaxProductModelLength, MinimumLength = MinProductModelLength)]
        public string Brand { get; set; }

        [Required]
        [StringLength(MaxProductDescriptionLength, MinimumLength = MinProductDescriptionLength)]
        public string Description { get; set; }

        [Range(0.01, 5000.00)]
        public decimal Price { get; set; }

        [Display(Name = "Is it Available")]
        public bool IsAvailable { get; set; }

        [Display(Name = "Image URL")]
        [Url]
        [Required]
        public string ImageUrl { get; set; }

        [Display(Name ="Sub Category")]
        public int SubCategoryId { get; set; }

        public IEnumerable<ProductSubCategoryViewModel> SubCategories { get; set; }
    }
}
