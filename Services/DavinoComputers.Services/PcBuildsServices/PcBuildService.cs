namespace DavinoComputers.Services.PcBuildsServices
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DavinoComputers.Data;
    using DavinoComputers.Data.Models;
    using DavinoComputers.Web.ViewModels.PcBuildViewModels;
    using DavinoComputers.Web.ViewModels.ProductViewModels;

    public class PcBuildService : IPcBuildService
    {
        private readonly ApplicationDbContext data;

        public PcBuildService(ApplicationDbContext data)
        {
            this.data = data;
        }

        public async Task CreatePcBuild(AddPcBuildInputModel pcbuild)
        {
            var cpudata = this.data.Products.FirstOrDefault(p => p.Id == pcbuild.ProductCPU);
            var gpu = this.data.Products.FirstOrDefault(p => p.Id == pcbuild.ProductGPU);
            var ram = this.data.Products.FirstOrDefault(p => p.Id == pcbuild.ProductRAM);
            var motherBoard = this.data.Products.FirstOrDefault(p => p.Id == pcbuild.ProductMotherBoard);
            var powerSupply = this.data.Products.FirstOrDefault(p => p.Id == pcbuild.ProductPowerSupply);
            var computerCase = this.data.Products.FirstOrDefault(p => p.Id == pcbuild.ProductComputerCase);

            var products = new HashSet<Product>();

            products.Add(cpudata);
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

        public AddPcBuildInputModel GetPcBuildById(string id)
        {
            // To Implement by autoMapper!!!
            return new AddPcBuildInputModel();
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
