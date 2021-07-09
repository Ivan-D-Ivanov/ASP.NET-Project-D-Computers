namespace DavinoComputers.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using DavinoComputers.Data.Common.Models;

    using static DavinoComputers.Common.GlobalConstants;

    public class Comment : BaseModel<int>
    {
        [Required]
        [MaxLength(MaxCommentContentLength)]
        public string Content { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}
