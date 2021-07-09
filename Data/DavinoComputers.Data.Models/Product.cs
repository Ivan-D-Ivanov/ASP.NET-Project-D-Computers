namespace DavinoComputers.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using DavinoComputers.Data.Common.Models;

    using static DavinoComputers.Common.GlobalConstants;

    public class Product : BaseDeletableModel<int>
    {
        public Product()
        {
            this.Comments = new HashSet<Comment>();
            this.Images = new HashSet<Image>();
        }

        [Required]
        [MaxLength(MaxProductNameLength)]
        public string Name { get; set; }

        public decimal Price { get; set; }

        [Range(MinProductRateLength,MaxProductRateLength)]
        public int Rate { get; set; }

        [Required]
        [MaxLength(MaxProductNameLength)]
        public string Brand { get; set; }

        [Required]
        [Url]
        public string ImageUrl { get; set; }

        public bool IsAvailable { get; set; }

        public int SubCategoryId { get; set; }

        public virtual SubCategory SubCategory { get; set; }

        public virtual IEnumerable<Comment> Comments { get; set; }

        public virtual IEnumerable<Image> Images { get; set; }
    }
}
