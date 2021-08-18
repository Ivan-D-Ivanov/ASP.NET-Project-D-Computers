namespace DavinoComputers.Services.Data.Tests.Data
{
    using DavinoComputers.Web.ViewModels.PcBuildViewModels;

    public static class OneWholePcBuildCorrectFormData
    {
        public static AddPcBuildFormModel FakeAddPcBuildForm
            => new AddPcBuildFormModel
            {
                Name = "PcBuildNameName",
                Description = "PcBuildNameNamePcBuildNameNamePcBuildNameNamePcBuildNameName",
                IsAvailable = true,
                Price = 1000,
                ImageUrl = "https://pcbuild.bg/js/admin/ckeditor/plugins/kcfinder/upload/images/PCBUILD%20Classic%201920x1080.png",
                ProductCPU = 1,
                ProductGPU = 2,
                ProductRAM = 3,
                ProductPowerSupply = 4,
                ProductComputerCase = 5,
                ProductMotherBoard = 6,
            };
    }
}
