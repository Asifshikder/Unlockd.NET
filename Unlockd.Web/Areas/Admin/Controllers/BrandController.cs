using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Unlockd.Domain.Entities.Device;
using Unlockd.Service.Interface;
using Unlockd.Web.Areas.Admin.Models.Brand;
using Unlockd.Web.Helpers;

namespace Unlockd.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class BrandController : Controller
    {
        private IBrandService brandService;
        private IFileHandler fileHandler;

        public BrandController(IBrandService brandService, IFileHandler fileHandler)
        {
            this.brandService = brandService;
            this.fileHandler = fileHandler;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var entityList = brandService.AllAsIEnumerable();
            return View(entityList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(BrandViewModel viewModel)
        {
            if (viewModel.BrandLogofile != null)
            {
                viewModel.BrandLogo = fileHandler.UploadFile("Brand", viewModel.BrandLogofile);
            }

            if (viewModel.FeaturedImageFile != null)
            {
                viewModel.FeaturedImage = fileHandler.UploadFile("Brand", viewModel.FeaturedImageFile);
            }
            if (viewModel.CovorPhotoFile != null)
            {
                viewModel.CovorPhoto = fileHandler.UploadFile("Brand", viewModel.CovorPhotoFile);
            }

            Brand brand = new Brand()
            {
                Name = viewModel.Name,
                BrandLogo = viewModel.BrandLogo,
                FeaturedImage = viewModel.FeaturedImage,
                ShortDescription = viewModel.ShortDescription,
                Description = viewModel.Description,
                AverageUnlockingPrice = viewModel.AverageUnlockingPrice
            };

            brandService.InsertEntity(brand);
            return Redirect("/Admin/Brand/Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var brand = brandService.GetById(id);

            BrandViewModel viewModel = new BrandViewModel()
            {
                Id = brand.Id,
                Name = brand.Name,
                BrandLogo = brand.BrandLogo,
                FeaturedImage = brand.FeaturedImage,
                CovorPhoto = brand.CovorPhoto,
                ShortDescription = brand.ShortDescription,
                Description = brand.Description,
                AverageUnlockingPrice = brand.AverageUnlockingPrice
            };

            return View(viewModel);
        }

        [HttpPost]
        [Route("/Admin/Brand/Update")]
        [AutoValidateAntiforgeryToken]
        public IActionResult Update(BrandViewModel viewModel)
        {
            if (viewModel.BrandLogofile != null)
            {
                viewModel.BrandLogo = fileHandler.UpdateFile(viewModel.BrandLogo, "Brand", viewModel.BrandLogofile);
            }

            if (viewModel.FeaturedImageFile != null)
            {
                viewModel.FeaturedImage = fileHandler.UpdateFile(viewModel.FeaturedImage, "Brand", viewModel.FeaturedImageFile);
            }
            if (viewModel.CovorPhotoFile != null)
            {
                viewModel.CovorPhoto = fileHandler.UpdateFile(viewModel.CovorPhoto, "Brand", viewModel.CovorPhotoFile);
            }

            Brand brand = new Brand()
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                BrandLogo = viewModel.BrandLogo,
                CovorPhoto = viewModel.CovorPhoto,
                FeaturedImage = viewModel.FeaturedImage,
                Description = viewModel.Description,
                ShortDescription = viewModel.ShortDescription,
                AverageUnlockingPrice = viewModel.AverageUnlockingPrice
            };

            brandService.UpdateEntity(brand);
            return Redirect("/Admin/Brand/index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var brand = brandService.GetById(id);
            return View(brand);
        }

        [HttpPost]
        [Route("/Admin/Brand/DeleteConfirm")]
        public IActionResult DeleteConfirm(Brand model)
        {
            if (model.BrandLogo != null)
            {
                fileHandler.DeleteFile(model.BrandLogo);
            }

            brandService.DeleteEntity(model);
            return Redirect("/Admin/Brand/Index");
        }

        [Route("/Admin/Brand/ChangeFeaturedStatus")]
        public IActionResult ChangeFeaturedStatus(int id)
        {
            var featuredCount = brandService.AllAsIEnumerable().Where(b => b.IsFeatured == true).Count();
            var brand = brandService.GetById(id);
            if (featuredCount >= 10 && !brand.IsFeatured)
            {
                return Redirect("/Admin/Brand/index");
            }
            else
            {
                brand.IsFeatured = !brand.IsFeatured;
                brandService.UpdateEntity(brand);
                return Redirect("/Admin/Brand/index");
            }
        }
    }
}