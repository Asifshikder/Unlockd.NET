using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unlockd.Domain.Entities.Auth;
using Unlockd.Domain.Entities.Device;
using Unlockd.Service.Interface;
using Unlockd.Service.Interface.Device;
using Unlockd.Service.Interface.Network;
using Unlockd.Service.Interface.Services;
using Unlockd.Web.Models;

namespace Unlockd.Web.Controllers
{
    [Authorize]
    public class UnlockPhoneController : Controller
    {
        private IBrandService brandService;
        private IDeviceModelService deviceModelService;
        private ICountryService countryService;
        private INetworkCarrierService networkCarrierService;
        private IBrandFAQService brandFAQService;
        private UserManager<User> userManager;
        private RoleManager<IdentityRole> roleManager;
        private SignInManager<User> signInManager;

        public UnlockPhoneController(IBrandService brandService,
            IDeviceModelService deviceModelService,
            ICountryService countryService,
            INetworkCarrierService networkCarrierService,
            IBrandFAQService brandFAQService,
            UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager,
            SignInManager<User> signInManager)
        {
            this.brandService = brandService;
            this.deviceModelService = deviceModelService;
            this.countryService = countryService;
            this.networkCarrierService = networkCarrierService;
            this.brandFAQService = brandFAQService;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var brandList = brandService.AllAsIEnumerable().Where(s=>s.Id!=18);
            return View(brandList);
        }
        [HttpGet]
        public IActionResult ByBrand(int id, int? modelid)
        {
            int countryId = 0;
            if (signInManager.IsSignedIn(User))
            {
                countryId = GetCountry();
            }
            UnlockPhoneViewModel viewmodel = new UnlockPhoneViewModel();

            viewmodel.BrandId = id;
            viewmodel.CountryId = countryId;
            viewmodel.UnlockTypeId = 5;
            viewmodel.TotalPrice = 0;
            viewmodel.CountryId = countryId;
            var model = brandService.GetById(id);
            if (id == 0 || model == null)
            {
                return View(viewmodel);
            }
            var modellist = deviceModelService.AllAsIEnumerable().Where(s => s.BrandId == id).ToList();
            DeviceModel deviceModel = new DeviceModel();
            deviceModel = modelid != null ? deviceModelService.GetById(modelid.Value) : null;
            if (deviceModel != null)
            {
                ViewBag.modellist = new SelectList(modellist.Where(s => s.BrandId == id).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name",deviceModel.Id);
            }
            else
            {
                ViewBag.modellist = new SelectList(modellist.Where(s => s.BrandId == id).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            }
            ViewBag.countryList = new SelectList(countryService.AllAsIEnumerable().Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name", countryId);
            ViewBag.NetworkList = new SelectList(networkCarrierService.AllAsIEnumerable().Where(s => s.CountryId == countryId && s.Id != 54).Select(s => new { Id = s.Id, Name = s.NetworkName }), "Id", "Name");

            var brandFAQList = brandFAQService.AllAsIEnumerable().Where(s => s.BrandId == id).ToList();
            viewmodel.Brand = model;
            viewmodel.BrandFAQs = brandFAQList;
            viewmodel.DeviceModel = deviceModel;
            viewmodel.DeviceModels = modellist;

            return View(viewmodel);
        }



        public int GetCountry()
        {
            var user = GetCurrentUser();
            return user.Result.CountryId.Value;
        }

        private async Task<User> GetCurrentUser()
        {
            var user = await userManager.GetUserAsync(HttpContext.User);
            return user;
        }
    }
}
