namespace DavinoComputers.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using DavinoComputers.Data.Common.Models;

    using static DavinoComputers.Common.GlobalConstants;

    public class PcBuild : BaseDeletableModel<int>
    {
        public PcBuild()
        {
            this.Products = new HashSet<Product>();
            this.Images = new HashSet<Image>();
            this.ShoppingCarts = new HashSet<ShoppingCart>();
        }

        [Required]
        [StringLength(MaxPcBuildNameLength, MinimumLength = MinPCBuildNameLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(MaxProductDescriptionLength)]
        public string Description { get; set; }

        public bool IsAvailable { get; set; }

        [Range(MinProductRateLength, MaxProductRateLength)]
        public int Rate { get; set; }

        [Required]
        [Url]
        public string ImageUrl { get; set; }

        [Range(00.1, 10000)]
        public decimal Price { get; set; }

        public virtual ICollection<Image> Images { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        public virtual ICollection<ShoppingCart> ShoppingCarts { get; set; }
    }
}
