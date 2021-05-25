using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using Unlockd.Domain.Entities.Device;
using Unlockd.Domain.Entities.SalesAndOrder;
using Unlockd.Service.Interface;
using Unlockd.Service.Interface.Device;
using Unlockd.Web.Models;

namespace Unlockd.Web.Controllers
{
    [Authorize]
    public class PhoneCheckController : Controller
    {
        private IBrandService brandService;
        private IDeviceModelService deviceModelService;
        public PhoneCheckController(IBrandService brandService,
            IDeviceModelService deviceModelService)
        {
            this.brandService = brandService;
            this.deviceModelService = deviceModelService;

        }

        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult CarrierCheck()
        {
            var BrandList = brandService.AllAsIEnumerable().Where(s=>s.Id!=18).ToList();
            BrandList.Insert(0, new Brand { Id = 0, Name = "Select" });
            ViewBag.BrandList = BrandList;
            CartViewModel cart = new CartViewModel()
            {
                TotalPrice = 0,
                UnlockTypeId = 1
            };

            return View(cart);
        }

        public IActionResult BlackListedCheck()
        {
            var BrandList = brandService.AllAsIEnumerable().Where(s => s.Id != 18).ToList();
            BrandList.Insert(0, new Brand { Id = 0, Name = "Select" });
            ViewBag.BrandList = BrandList;
            CartViewModel cart = new CartViewModel()
            {
                TotalPrice = 0,
                UnlockTypeId = 2
            };

            return View(cart);
        }

        public IActionResult icloudactivation()
        {
            var BrandList = brandService.AllAsIEnumerable().Where(s => s.Id != 18).ToList();
            BrandList.Insert(0, new Brand { Id = 0, Name = "Select" });
            ViewBag.BrandList = BrandList;
            CartViewModel cart = new CartViewModel()
            {
                TotalPrice = 0,
                UnlockTypeId = 3
            };

            return View(cart);
        }

        public IActionResult SprintStatus()
        {
            var BrandList = brandService.AllAsIEnumerable().Where(s => s.Id != 18).ToList();
            BrandList.Insert(0, new Brand { Id = 0, Name = "Select" });
            ViewBag.BrandList = BrandList;
            CartViewModel cart = new CartViewModel()
            {
                TotalPrice = 0,
                UnlockTypeId = 3
            };

            return View(cart);
        }
    }
}
