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
            this.Comments = new HashSet<Comment>();
            this.Images = new HashSet<Image>();
        }

        [Required]
        [StringLength(MaxPcBuildNameLength, MinimumLength = MinPCBuildNameLength)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public bool IsAvailable { get; set; }

        public int Rate { get; set; }

        public virtual IEnumerable<Image> Images { get; set; }

        public virtual IEnumerable<Product> Products { get; set; }

        public virtual IEnumerable<Comment> Comments { get; set; }
    }
}
