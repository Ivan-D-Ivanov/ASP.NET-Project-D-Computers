namespace DavinoComputers.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    using DavinoComputers.Data.Common.Models;

    public class ShoppingCart : BaseDeletableModel<int>
    {
        public ShoppingCart()
        {
            this.Products = new HashSet<Product>();
            this.PcBuilds = new HashSet<PcBuild>();
        }

        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public ICollection<Product> Products { get; set; }

        public ICollection<PcBuild> PcBuilds { get; set; }
    }
}
