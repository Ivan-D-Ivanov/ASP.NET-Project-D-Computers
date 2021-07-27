namespace DavinoComputers.Web.ViewModels.PcBuildViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using DavinoComputers.Data.Models;
    using DavinoComputers.Web.ViewModels.ProductViewModels;

    using static DavinoComputers.Common.GlobalConstants;

    public class AddPcBuildInputModel
    {
        [Required]
        [StringLength(MaxProductModelLength, MinimumLength = MinProductModelLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(MaxProductDescriptionLength, MinimumLength = MinProductDescriptionLength)]
        public string Description { get; set; }

        [Range(0.01, 5000.00)]
        public decimal Price { get; set; }

        [Display(Name = "Is it Available")]
        public bool IsAvailable { get; set; }

        [Display(Name = "Image URL")]
        [Url]
        [Required]
        public string ImageUrl { get; set; }

        [Display(Name = "CPU")]
        public int ProductCPU { get; set; }

        public IEnumerable<PcBuildProductsInputModel> CpuProducts { get; set; }

        [Display(Name = "GPU")]
        public int ProductGPU { get; set; }

        public IEnumerable<PcBuildProductsInputModel> GpuProducts { get; set; }

        [Display(Name = "Mother Board")]
        public int ProductMotherBoard { get; set; }

        public IEnumerable<PcBuildProductsInputModel> MotherBoardProducts { get; set; }

        [Display(Name = "RAM")]
        public int ProductRAM { get; set; }

        public IEnumerable<PcBuildProductsInputModel> RamProducts { get; set; }

        [Display(Name = "Power Supply")]
        public int ProductPowerSupply { get; set; }

        public IEnumerable<PcBuildProductsInputModel> PowerSupplyProducts { get; set; }

        [Display(Name = "Computer Case")]
        public int ProductComputerCase { get; set; }

        public IEnumerable<PcBuildProductsInputModel> ComputerCasesProducts { get; set; }
    }
}
