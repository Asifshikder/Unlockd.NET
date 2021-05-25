using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Threading.Tasks;
using Unlockd.Domain.Entities.Auth;
using Unlockd.Domain.Entities.Network;
using Unlockd.Service.Interface;
using Unlockd.Service.Interface.Device;
using Unlockd.Service.Interface.Network;
using Unlockd.Service.Interface.Services;
using Unlockd.Web.Areas.Admin.Models.Network;
using Unlockd.Web.Models;

namespace Unlockd.Web.ViewComponents
{
    public class HomeUnlockViewComponent : ViewComponent
    {
        private IBrandService brandService;
        private IDeviceModelService deviceModelService;
        private ICountryService countryService;
        private INetworkCarrierService networkCarrierService;
        private IBrandFAQService brandFAQService;
        private UserManager<User> userManager;
        private RoleManager<IdentityRole> roleManager;
        private SignInManager<User> signInManager;
        public HomeUnlockViewComponent(IBrandService brandService,
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

        public async Task<IViewComponentResult> InvokeAsync()
        {
            CartViewModel model = new CartViewModel();
            model.BrandId = 0;
            model.UnlockTypeId = 5;
            model.TotalPrice = 0;
            model.CountryId = 0;
            ViewBag.countryList = new SelectList(countryService.AllAsIEnumerable().Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            ViewBag.brandList = new SelectList(brandService.AllAsIEnumerable().Where(s=>s.Id!=18).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            return View(model);
        }
    }
}
