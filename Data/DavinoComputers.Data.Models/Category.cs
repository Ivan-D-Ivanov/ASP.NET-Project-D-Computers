namespace DavinoComputers.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using DavinoComputers.Data.Common.Models;

    using static DavinoComputers.Common.GlobalConstants;

    public class Category : BaseDeletableModel<int>
    {
        public Category()
        {
            this.SubCategories = new HashSet<SubCategory>();
        }

        [Required]
        [MaxLength(MaxCategoryNameLength)]
        public string Name { get; set; }

        public virtual IEnumerable<SubCategory> SubCategories { get; set; }
    }
}
