namespace DavinoComputers.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using DavinoComputers.Data.Common.Models;

    public class Image : BaseDeletableModel<string>
    {
        public Image()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        public string Extension { get; set; }
    }
}
