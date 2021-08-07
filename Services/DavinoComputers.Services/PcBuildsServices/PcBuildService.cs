namespace DavinoComputers.Services.PcBuildsServices
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DavinoComputers.Data;
    using DavinoComputers.Data.Models;
    using DavinoComputers.Web.ViewModels.PcBuildViewModels;
    using DavinoComputers.Web.ViewModels.ProductViewModels;
    using Microsoft.EntityFrameworkCore;

    public class PcBuildService : IPcBuildService
    {
        private readonly ApplicationDbContext data;

        public PcBuildService(ApplicationDbContext data)
        {
            this.data = data;
        }

        public async Task CreatePcBuild(AddPcBuildFormModel pcbuild)
        {
            var cpu = this.data.Products.FirstOrDefault(p => p.Id == pcbuild.ProductCPU);
            var gpu = this.data.Products.FirstOrDefault(p => p.Id == pcbuild.ProductGPU);
            var ram = this.data.Products.FirstOrDefault(p => p.Id == pcbuild.ProductRAM);
            var motherBoard = this.data.Products.FirstOrDefault(p => p.Id == pcbuild.ProductMotherBoard);
            var powerSupply = this.data.Products.FirstOrDefault(p => p.Id == pcbuild.ProductPowerSupply);
            var computerCase = this.data.Products.FirstOrDefault(p => p.Id == pcbuild.ProductComputerCase);

            var products = new HashSet<Product>();

            products.Add(cpu);
            products.Add(gpu);
            products.Add(ram);
            products.Add(motherBoard);
            products.Add(powerSupply);
            products.Add(computerCase);

            var newPcBUild = new PcBuild
            {
                Name = pcbuild.Name,
                Description = pcbuild.Description,
                IsAvailable = pcbuild.IsAvailable,
                Price = pcbuild.Price,
                ImageUrl = pcbuild.ImageUrl,
                Products = products,
            };

            await this.data.PcBuilds.AddAsync(newPcBUild);
            await this.data.SaveChangesAsync();
        }

        public bool EditPcBuild(int id, AddPcBuildFormModel pcbuild)
        {
            var currnetPcBuild = this.data.PcBuilds.Include(pc => pc.Products).FirstOrDefault(pc => pc.Id == id);

            if (currnetPcBuild == null)
            {
                return false;
            }

            currnetPcBuild.Name = pcbuild.Name;
            currnetPcBuild.Description = pcbuild.Description;
            currnetPcBuild.IsAvailable = pcbuild.IsAvailable;
            currnetPcBuild.Price = pcbuild.Price;
            currnetPcBuild.ImageUrl = pcbuild.ImageUrl;

            currnetPcBuild.Products.Clear();
            var cpu = this.data.Products.FirstOrDefault(p => p.Id == pcbuild.ProductCPU);
            var gpu = this.data.Products.FirstOrDefault(p => p.Id == pcbuild.ProductGPU);
            var ram = this.data.Products.FirstOrDefault(p => p.Id == pcbuild.ProductRAM);
            var motherBoard = this.data.Products.FirstOrDefault(p => p.Id == pcbuild.ProductMotherBoard);
            var powerSupply = this.data.Products.FirstOrDefault(p => p.Id == pcbuild.ProductPowerSupply);
            var computerCase = this.data.Products.FirstOrDefault(p => p.Id == pcbuild.ProductComputerCase);

            var products = new HashSet<Product>();
            products.Add(cpu);
            products.Add(gpu);
            products.Add(ram);
            products.Add(motherBoard);
            products.Add(powerSupply);
            products.Add(computerCase);
            currnetPcBuild.Products = products;

            this.data.Update(currnetPcBuild);
            this.data.SaveChanges();
            return true;
        }

        public AddPcBuildFormModel GetPcBuildById(int id)
        {
            // To Implement by autoMapper!!!
            var pcbuild = this.data.PcBuilds
                .Include(d => d.Products)
                .ThenInclude(d => d.SubCategory)
                .Where(pc => pc.Id == id)
                .FirstOrDefault();

            int productCpuId = pcbuild.Products.Where(p => p.SubCategory.Name == "CPU").Select(p => p.Id).FirstOrDefault();
            int productGpuId = pcbuild.Products.Where(p => p.SubCategory.Name == "GPU").Select(p => p.Id).FirstOrDefault();
            int productRamId = pcbuild.Products.Where(p => p.SubCategory.Name == "RAM").Select(p => p.Id).FirstOrDefault();
            int productMbId = pcbuild.Products.Where(p => p.SubCategory.Name == "Mother Boards").Select(p => p.Id).FirstOrDefault();
            int productPsId = pcbuild.Products.Where(p => p.SubCategory.Name == "Power Supply").Select(p => p.Id).FirstOrDefault();
            int productCaseId = pcbuild.Products.Where(p => p.SubCategory.Name == "Computer Cases").Select(p => p.Id).FirstOrDefault();

            return new AddPcBuildFormModel
            {
                Name = pcbuild.Name,
                Description = pcbuild.Description,
                IsAvailable = pcbuild.IsAvailable,
                Price = pcbuild.Price,
                ImageUrl = pcbuild.ImageUrl,
                ProductCPU = productCpuId,
                ProductGPU = productGpuId,
                ProductRAM = productRamId,
                ProductMotherBoard = productMbId,
                ProductPowerSupply = productPsId,
                ProductComputerCase = productCaseId,
                CpuProducts = this.GetCpuProducts(),
                GpuProducts = this.GetGpuProducts(),
                MotherBoardProducts = this.GetMotherBoardProducts(),
                RamProducts = this.GetRamProducts(),
                PowerSupplyProducts = this.GetPowerSupplyProducts(),
                ComputerCasesProducts = this.GetComputerCaseProducts(),
            };
        }

        public IEnumerable<PcBuildProductsInputModel> GetComputerCaseProducts()
        {
            return this.data.Products
                .Where(p => p.SubCategory.Name == "Computer Cases")
                .Select(p => new PcBuildProductsInputModel
                {
                    Id = p.Id,
                    Model = p.Model,
                    Brand = p.Brand,
                })
                .ToList();
        }

        public IEnumerable<PcBuildProductsInputModel> GetCpuProducts()
        {
            return this.data.Products
                .Where(p => p.SubCategory.Name == "CPU")
                .Select(p => new PcBuildProductsInputModel
                {
                    Id = p.Id,
                    Model = p.Model,
                    Brand = p.Brand,
                })
                .ToList();
        }

        public IEnumerable<PcBuildProductsInputModel> GetGpuProducts()
        {
            return this.data.Products
                .Where(p => p.SubCategory.Name == "GPU")
                .Select(p => new PcBuildProductsInputModel
                {
                    Id = p.Id,
                    Model = p.Model,
                    Brand = p.Brand,
                })
                .ToList();
        }

        public IEnumerable<PcBuildProductsInputModel> GetMotherBoardProducts()
        {
            return this.data.Products
                 .Where(p => p.SubCategory.Name == "Mother Boards")
                 .Select(p => new PcBuildProductsInputModel
                 {
                     Id = p.Id,
                     Model = p.Model,
                     Brand = p.Brand,
                 })
                 .ToList();
        }

        public IEnumerable<PcBuildProductsInputModel> GetPowerSupplyProducts()
        {
            return this.data.Products
                .Where(p => p.SubCategory.Name == "Power Supply")
                .Select(p => new PcBuildProductsInputModel
                {
                    Id = p.Id,
                    Model = p.Model,
                    Brand = p.Brand,
                })
                .ToList();
        }

        public IEnumerable<PcBuildProductsInputModel> GetRamProducts()
        {
            return this.data.Products
                 .Where(p => p.SubCategory.Name == "RAM")
                 .Select(p => new PcBuildProductsInputModel
                 {
                     Id = p.Id,
                     Model = p.Model,
                     Brand = p.Brand,
                 })
                 .ToList();
        }

        public IEnumerable<PcBuildInListModel> ListAllPcBuilds()
        {
            return this.data.PcBuilds.AsQueryable()
                .Select(pc => new PcBuildInListModel
                {
                     Id = pc.Id,
                     Name = pc.Name,
                     Description = pc.Description,
                     IsAvailable = pc.IsAvailable,
                     ImageUrl = pc.ImageUrl,
                     Rate = pc.Rate,
                     Price = pc.Price,
                     Products = pc.Products.Select(p => new ProductInListViewModel
                     {
                         Id = p.Id,
                         Model = p.Model,
                         Brand = p.Brand,
                         Description = p.Description,
                         ImageUrl = p.ImageUrl,
                     }),
                })
                .ToList();
        }
    }
}
