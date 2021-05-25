using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using Unlockd.Domain.Entities.Device;
using Unlockd.Service.Interface;
using Unlockd.Service.Interface.Device;
using Unlockd.Web.Areas.Admin.Models.Brand;
using Unlockd.Web.Helpers;

namespace Unlockd.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class DeviceModelController : Controller
    {
        private IDeviceModelService deviceModelService;
        private IBrandService brandService;
        private IFileHandler fileHandler;

        public DeviceModelController(
            IDeviceModelService deviceModelService,
            IBrandService brandService,
            IFileHandler fileHandler)
        {
            this.deviceModelService = deviceModelService;
            this.brandService = brandService;
            this.fileHandler = fileHandler;
        }

        [HttpGet]
        public IActionResult Index(int? id)
        {
            if (id != null)
            {
                var entityList = deviceModelService.AllAsIEnumerable().Where(s => s.BrandId == id.Value);
                foreach (var item in entityList)
                {
                    item.Brand = brandService.GetById(item.BrandId);
                }
                return View(entityList);
            }
            else
            {
                var entityList = deviceModelService.AllAsIEnumerable();
                foreach (var item in entityList)
                {
                    item.Brand = brandService.GetById(item.BrandId);
                }
                return View(entityList);
            }

        }

        [HttpGet]
        public IActionResult Create(int? id)
        {
            if (id != null)
            {
                ViewBag.brandList = new SelectList(brandService.AllAsIEnumerable().Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name",id.Value);
                return View();
            }
            else
            {
                ViewBag.brandList = new SelectList(brandService.AllAsIEnumerable().Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
                return View();
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(DeviceModelViewModel viewModel)
        {
            if (viewModel.ImageFile != null)
            {
                viewModel.Image = fileHandler.UploadFile("Devices", viewModel.ImageFile);
            }

            DeviceModel device = new DeviceModel()
            {
                Name = viewModel.Name,
                Image = viewModel.Image,
                Charge = viewModel.Charge,
                BrandId = viewModel.BrandId
            };

            deviceModelService.InsertEntity(device);
            return Redirect("/Admin/DeviceModel/Index?id="+viewModel.BrandId+"");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.brandList = new SelectList(brandService.AllAsIEnumerable().Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");

            var deviceModel = deviceModelService.GetById(id);

            DeviceModelViewModel viewModel = new DeviceModelViewModel()
            {
                Id = deviceModel.Id,
                Name = deviceModel.Name,
                Image = deviceModel.Image,
                Charge = deviceModel.Charge.Value,
                BrandId = deviceModel.BrandId
            };

            return View(viewModel);
        }

        [HttpPost]
        [Route("/Admin/DeviceModel/Update")]
        [AutoValidateAntiforgeryToken]
        public IActionResult Update(DeviceModelViewModel viewModel)
        {
            if (viewModel.ImageFile != null)
            {
                viewModel.Image = fileHandler.UpdateFile(viewModel.Image, "Brand", viewModel.ImageFile);
            }

            DeviceModel deviceModel = new DeviceModel()
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                Image = viewModel.Image,
                Charge = viewModel.Charge,
                BrandId = viewModel.BrandId
            };

            deviceModelService.UpdateEntity(deviceModel);
            return Redirect("/Admin/DeviceModel/Index?id=" + viewModel.BrandId + "");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var deviceModel = deviceModelService.GetById(id);
            return View(deviceModel);
        }

        [HttpPost]
        [Route("/Admin/DeviceModel/DeleteConfirm")]
        [AutoValidateAntiforgeryToken]
        public IActionResult DeleteConfirm(DeviceModel model)
        {
            if (model.Image != null)
            {
                fileHandler.DeleteFile(model.Image);
            }
            deviceModelService.DeleteEntity(model);
            return Redirect("/Admin/DeviceModel/Index?id=" + model.BrandId + "");
        }

        public IActionResult ChangeFeaturedStatus(int id)
        {
            var featuredCount = deviceModelService.AllAsIEnumerable().Where(b => b.IsFeatured == true).Count();
            var deviceModel = deviceModelService.GetById(id);
            if (featuredCount >= 4 && !deviceModel.IsFeatured)
            {
                return Redirect("/Admin/DeviceModel/index");
            }
            else
            {
                deviceModel.IsFeatured = !deviceModel.IsFeatured;
                deviceModelService.UpdateEntity(deviceModel);
                return Redirect("/Admin/DeviceModel/index");
            }
        }
    }
}