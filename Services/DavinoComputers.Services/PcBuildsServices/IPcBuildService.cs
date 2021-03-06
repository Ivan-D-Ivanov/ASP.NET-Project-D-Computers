namespace DavinoComputers.Services.PcBuildsServices
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DavinoComputers.Web.ViewModels.PcBuildViewModels;

    public interface IPcBuildService
    {
        IEnumerable<PcBuildProductsInputModel> GetCpuProducts();

        IEnumerable<PcBuildProductsInputModel> GetGpuProducts();

        IEnumerable<PcBuildProductsInputModel> GetRamProducts();

        IEnumerable<PcBuildProductsInputModel> GetMotherBoardProducts();

        IEnumerable<PcBuildProductsInputModel> GetPowerSupplyProducts();

        IEnumerable<PcBuildProductsInputModel> GetComputerCaseProducts();

        Task CreatePcBuild(AddPcBuildFormModel pcbuild);

        ICollection<PcBuildInListModel> ListAllPcBuilds();

        AddPcBuildFormModel GetPcBuildForm(int id);

        bool EditPcBuild(int id, AddPcBuildFormModel pcbuild);

        PcBuildDetailsModel GetPcBuildDetails(int id);
    }
}
