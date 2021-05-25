using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unlockd.Domain.Entities.Pricings;
using Unlockd.Service.Implementation.Device;
using Unlockd.Service.Interface;
using Unlockd.Service.Interface.Device;
using Unlockd.Service.Interface.Network;
using Unlockd.Web.Areas.Admin.Models.Pricings;

namespace Unlockd.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ModelVsCarrierController : Controller
    {
        private IModelVsCarrierService modelVsCarrierService;
        private IBrandService brandService;
        private IDeviceModelService deviceModelService;
        private INetworkCarrierService networkCarrierService;

        public ModelVsCarrierController(IModelVsCarrierService modelVsCarrierService,
            IBrandService brandService,
            IDeviceModelService deviceModelService,
            INetworkCarrierService networkCarrierService)
        {
            this.modelVsCarrierService = modelVsCarrierService;
            this.brandService = brandService;
            this.deviceModelService = deviceModelService;
            this.networkCarrierService = networkCarrierService;
        }
        [HttpGet]
        public IActionResult Index(int id)
        {
            ViewBag.pageId = id;
            var deviceLists = modelVsCarrierService.AllAsIEnumerable().Where(s => s.NetworkCarrierId == id).ToList();
            List<ModelVsCarrierViewModel> models = new List<ModelVsCarrierViewModel>();
            foreach (var item in deviceLists)
            {
                ModelVsCarrierViewModel model = new ModelVsCarrierViewModel();
                var devicemodel = item.DeviceModelId != 0 ? deviceModelService.GetById(item.DeviceModelId) : null;
                model.Id = item.Id;
                model.NetworkCarrierId = item.NetworkCarrierId;
                model.CarrierName = item.NetworkCarrierId != 0 ? networkCarrierService.GetById(item.NetworkCarrierId).NetworkName : "";
                model.DeviceModelId = item.DeviceModelId;
                model.ModelName = devicemodel != null ? devicemodel.Name : "";
                model.BrandName = devicemodel != null ? brandService.GetById(devicemodel.BrandId).Name : "";
                model.HasPremiumService = item.HasPremiumService;
                model.BasePrice = item.BasePrice;
                model.PremiumPrice = item.PremiumPrice;
                models.Add(model);
            }
            return View(models);
        }
        [HttpGet]
        public IActionResult Create(int id)
        {
            ModelVsCarrier model =new  ModelVsCarrier();
            model.NetworkCarrierId = id;
            ViewBag.pageId = id;
            ViewBag.brandList = new SelectList(brandService.AllAsIEnumerable().Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ModelVsCarrier model)
        {
            model.Id = 0;
            modelVsCarrierService.InsertEntity(model);
            return Redirect("/admin/ModelVsCarrier/Index?id="+model.NetworkCarrierId+"");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = modelVsCarrierService.GetById(id);
            var deviceModel = deviceModelService.GetById(model.DeviceModelId);
            ViewBag.brandList = new SelectList(brandService.AllAsIEnumerable().Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name", deviceModel.BrandId);
            ViewBag.devicemodels = new SelectList(deviceModelService.AllAsIEnumerable().Where(s=>s.BrandId==deviceModel.BrandId).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name", model.DeviceModelId);
            return View(model);
        }
        [HttpPost]
        [Route("/Admin/ModelVsCarrier/Update")]
        [AutoValidateAntiforgeryToken]
        public IActionResult Update(ModelVsCarrier model)
        {
            modelVsCarrierService.UpdateEntity(model);
            return Redirect("/admin/ModelVsCarrier/Index?id=" + model.NetworkCarrierId + "");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var model = modelVsCarrierService.GetById(id);
            var deviceModel = deviceModelService.GetById(model.DeviceModelId);
            ViewBag.brandList = new SelectList(brandService.AllAsIEnumerable().Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name", deviceModel.BrandId);
            ViewBag.devicemodels = new SelectList(deviceModelService.AllAsIEnumerable().Where(s => s.BrandId == deviceModel.BrandId).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name", model.DeviceModelId);
            return View(model);
        }

        [HttpPost]
        [Route("/Admin/ModelVsCarrier/DeleteConfirm")]
        [AutoValidateAntiforgeryToken]
        public IActionResult DeleteConfirm(ModelVsCarrier model)
        {
            int pageid = model.Id;
            modelVsCarrierService.DeleteEntity(model);
            return Redirect("/admin/NetworkCarrier/Index");
        }
        public JsonResult GetBrandDevices(int id)
        {
            var devicelsit = deviceModelService.AllAsIEnumerable().Where(b => b.BrandId == id).ToList();

            return Json(new SelectList(devicelsit, "Id", "NetworkName"));
        }
    }
}
