namespace DavinoComputers.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using DavinoComputers.Data.Common.Models;

    using static DavinoComputers.Common.GlobalConstants;

    public class Product : BaseDeletableModel<int>
    {
        public Product()
        {
            this.Images = new HashSet<Image>();
            this.PcBuilds = new HashSet<PcBuild>();
            this.ShoppingCarts = new HashSet<ShoppingCart>();
            this.Votes = new HashSet<Vote>();
        }

        [Required]
        [MaxLength(MaxProductModelLength)]
        public string Model { get; set; }

        [Required]
        [MaxLength(MaxProductModelLength)]
        public string Brand { get; set; }

        [Required]
        [MaxLength(MaxProductDescriptionLength)]
        public string Description { get; set; }

        public decimal Price { get; set; }

        [Required]
        [Url]
        public string ImageUrl { get; set; }

        public bool IsAvailable { get; set; }

        public int SubCategoryId { get; set; }

        public virtual SubCategory SubCategory { get; set; }

        public virtual ICollection<Image> Images { get; set; }

        public virtual ICollection<PcBuild> PcBuilds { get; set; }

        public virtual ICollection<ShoppingCart> ShoppingCarts { get; set; }

        public virtual ICollection<Vote> Votes { get; set; }
    }
}
