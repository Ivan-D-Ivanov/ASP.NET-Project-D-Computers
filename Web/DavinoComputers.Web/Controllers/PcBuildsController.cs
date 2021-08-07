namespace DavinoComputers.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using DavinoComputers.Services.CategoryServices;
    using DavinoComputers.Services.PcBuildsServices;
    using DavinoComputers.Services.ProductServices;
    using DavinoComputers.Web.ViewModels.PcBuildViewModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class PcBuildsController : BaseController
    {
        private readonly IPcBuildService pcbuildService;
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;

        public PcBuildsController(ICategoryService categoryService, IProductService productService, IPcBuildService pcbuildService)
        {
            this.categoryService = categoryService;
            this.productService = productService;
            this.pcbuildService = pcbuildService;
        }

        [Authorize(Roles = Common.GlobalConstants.AdministratorRoleName)]
        public IActionResult Add()
        {
            return this.View(new AddPcBuildFormModel
            {
                CpuProducts = this.pcbuildService.GetCpuProducts(),
                GpuProducts = this.pcbuildService.GetGpuProducts(),
                MotherBoardProducts = this.pcbuildService.GetMotherBoardProducts(),
                RamProducts = this.pcbuildService.GetRamProducts(),
                PowerSupplyProducts = this.pcbuildService.GetPowerSupplyProducts(),
                ComputerCasesProducts = this.pcbuildService.GetComputerCaseProducts(),
            });
        }

        [Authorize(Roles = Common.GlobalConstants.AdministratorRoleName)]
        [HttpPost]
        public async Task<IActionResult> Add(AddPcBuildFormModel pcbuild)
        {
            // TODO Ifs
            if (!this.pcbuildService.GetCpuProducts().Any(p => p.Id == pcbuild.ProductCPU))
            {
                this.ModelState.AddModelError(nameof(pcbuild.ProductCPU), "This kind of product doesn't exist");
            }

            if (!this.ModelState.IsValid)
            {
                pcbuild.CpuProducts = this.pcbuildService.GetCpuProducts();
                return this.View(pcbuild);
            }

            await this.pcbuildService.CreatePcBuild(pcbuild);

            return this.Redirect("/");
        }

        public IActionResult All()
        {
            var listPcBuilds = new ListingPcBuildsViewModel
            {
                PcBuilds = this.pcbuildService.ListAllPcBuilds(),
            };
            return this.View(listPcBuilds);
        }

        [Authorize(Roles = Common.GlobalConstants.AdministratorRoleName)]
        public IActionResult Edit(int id)
        {
            var pcbuild = this.pcbuildService.GetPcBuildById(id);
            if (pcbuild == null)
            {
                return this.NotFound();
            }

            return this.View(pcbuild);
        }

        [Authorize(Roles = Common.GlobalConstants.AdministratorRoleName)]
        [HttpPost]
        public IActionResult Edit(int id, AddPcBuildFormModel pcbuild)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(pcbuild);
            }

            this.pcbuildService.EditPcBuild(id, pcbuild);
            return this.RedirectToAction(nameof(this.All));
        }
    }
}
