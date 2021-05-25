using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;
using Unlockd.Domain.Entities.Device;
using Unlockd.Domain.Entities.Network;
using Unlockd.Domain.Entities.SalesAndOrder;
using Unlockd.Service.Interface;
using Unlockd.Service.Interface.Device;
using Unlockd.Service.Interface.Network;
using Unlockd.Web.Areas.Admin.Models.Brand;
using Unlockd.Web.Areas.Admin.Models.Network;
using Unlockd.Web.Models;

namespace Unlockd.Web.Controllers
{
    [Authorize]
    public class DeviceController : Controller
    {
        private IBrandService brandService;
        private IDeviceModelService deviceModelService;
        private ICountryService countryService;
        private INetworkCarrierService networkCarrierService;

        public DeviceController(
            IBrandService brandService,
            IDeviceModelService deviceModelService,
            ICountryService countryService,
            INetworkCarrierService networkCarrierService)
        {

            this.brandService = brandService;
            this.deviceModelService = deviceModelService;
            this.countryService = countryService;
            this.networkCarrierService = networkCarrierService;
        }

        public IActionResult Index()
        {
            var brands = brandService.AllAsIEnumerable();

            DeviceIndexViewModel viewModel = new DeviceIndexViewModel()
            {
                Brands = brands.Select(b => new BrandViewModel()
                {
                    Id = b.Id,
                    Name = b.Name,
                    BrandLogo = b.BrandLogo,
                    FeaturedImage = b.FeaturedImage,
                    AverageUnlockingPrice = b.AverageUnlockingPrice,
                    Devices = deviceModelService.AllAsIEnumerable().Where(d => d.BrandId == b.Id)
                })
            };

            int countryId = Int32.Parse(HttpContext.Session.GetString("countryId"));
            var BrandList = brandService.AllAsIEnumerable().Where(s => s.Id != 18).ToList();
            var CarrierList = networkCarrierService.AllAsIEnumerable().Where(b => b.CountryId == countryId&&b.Id!=54).ToList();
            BrandList.Insert(0, new Brand { Id = 0, Name = "Select" });
            CarrierList.Insert(0, new NetworkCarrier { Id = 0, NetworkName = "Select" });
            ViewBag.BrandList = BrandList;
            ViewBag.CarrierList = CarrierList;
            ViewBag.Country = countryService.GetById(countryId).Name;

            return View(viewModel);
        }

        public IActionResult Select(int? id)
        {
            if (id == null)
            {
                return View();
            }

            var device = deviceModelService.GetById(id.Value);
            device.Brand = brandService.GetById(device.BrandId);

            CartViewModel order = new CartViewModel()
            {
                DeviceModelId = id.Value,
                //DeviceModel = device,
                //TotalPrice = device.Charge.Value,
                //UnlockType = 5
            };

            int countryId = Int32.Parse(HttpContext.Session.GetString("countryId"));
            var CarrierList = networkCarrierService.AllAsIEnumerable().Where(b => b.CountryId == countryId&&b.Id!=54).ToList();
            CarrierList.Insert(0, new NetworkCarrier { Id = 0, NetworkName = "Select" });
            ViewBag.CarrierList = CarrierList;
            ViewBag.Country = countryService.GetById(countryId).Name;

            return View(order);
        }

        public IActionResult SetCountry(int id)
        {
            HttpContext.Session.SetString("countryId", id.ToString());
            return RedirectToAction(nameof(Index));
        }

        public JsonResult GetDeviceModel(int BrandId)
        {
            var deviceModelList = deviceModelService.AllAsIEnumerable().Where(b => b.BrandId == BrandId).ToList();

            return Json(new SelectList(deviceModelList, "Id", "Name"));
        }

    }
}
