namespace DavinoComputers.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using DavinoComputers.Data.Common.Models;

    using static DavinoComputers.Common.GlobalConstants;

    public class SubCategory : BaseDeletableModel<int>
    {
        public SubCategory()
        {
            this.Products = new HashSet<Product>();
        }

        [Required]
        [MaxLength(MaxCategoryNameLength)]
        public string Name { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public virtual IEnumerable<Product> Products { get; set; }
    }
}
