namespace DavinoComputers.Web.Controllers
{
    using System;
    using System.Collections.Generic;
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
            return this.View(new AddPcBuildInputModel
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
        public async Task<IActionResult> Add(AddPcBuildInputModel pcbuild)
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

        public IActionResult Edit(string id)
        {
            var pcbuild = this.pcbuildService.GetPcBuildById(id);
            return this.View();
        }
    }
}
