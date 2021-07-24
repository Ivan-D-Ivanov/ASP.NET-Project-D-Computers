namespace DavinoComputers.Data.Models
{
    using System.ComponentModel.DataAnnotations;

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

        public int PcBuildId { get; set; }

        public PcBuild PcBuild { get; set; }
    }
}
