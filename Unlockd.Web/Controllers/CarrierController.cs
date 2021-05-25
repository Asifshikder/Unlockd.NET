using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;
using System.Threading.Tasks;
using Unlockd.Domain.Entities.Auth;
using Unlockd.Domain.Entities.Device;
using Unlockd.Domain.Entities.SalesAndOrder;
using Unlockd.Service.Interface;
using Unlockd.Service.Interface.Blog;
using Unlockd.Service.Interface.Device;
using Unlockd.Service.Interface.Network;
using Unlockd.Service.Interface.Orders;
using Unlockd.Web.Areas.Admin.Models.Blog;
using Unlockd.Web.Areas.Admin.Models.Network;
using Unlockd.Web.Models;
using Unlockd.Web.Models.UnlockModels;

namespace Unlockd.Web.Controllers
{
    [Authorize]
    public class CarrierController : Controller
    {
        private ICountryService countryService;
        private INetworkCarrierService networkCarrierService;
        private IBrandService brandService;
        private UserManager<User> userManager;
        private RoleManager<IdentityRole> roleManager;
        private SignInManager<User> signInManager;
        private IDeviceModelService deviceModelService;
        private IOrderService orderService;

        public CarrierController(
            ICountryService countryService,
            INetworkCarrierService networkCarrierService,
            IDeviceModelService deviceModelService, IBrandService brandService,
            IOrderService orderService,
            UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager,
            SignInManager<User> signInManager)
        {

            this.countryService = countryService;
            this.networkCarrierService = networkCarrierService;
            this.deviceModelService = deviceModelService;
            this.orderService = orderService;
            this.brandService = brandService;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.signInManager = signInManager;
        }

        public IActionResult Index()
        {
            int id = 0;
            if (signInManager.IsSignedIn(User))
            {
                id = GetCountry();
            }
            var country = countryService.GetById(id);
            var countries = countryService.AllAsIEnumerable();

            CarrierIndexViewModel viewModel = new CarrierIndexViewModel()
            {
                Country = new CountryViewModel()
                {
                    Id = country.Id,
                    Name = country.Name,
                    DisplayName = country.DisplayName,
                    FlagIcon = country.FlagIcon,
                    Currency = country.Currency,
                    Carriers = networkCarrierService.AllAsIEnumerable().Where(b => b.CountryId == country.Id&& b.Id != 54).Select(c => new NetworkCarrierViewModel()
                    {
                        Id = c.Id,
                        NetworkName = c.NetworkName,
                        CarrierIcon = c.CarrierIcon,
                        BasePrice = c.BasePrice.Value,
                        Country = country
                    })
                },

                Countries = countries.Select(b => new CountryViewModel()
                {
                    Id = b.Id,
                    Name = b.Name,
                    DisplayName = b.DisplayName,
                    FlagIcon = b.FlagIcon,
                    Currency = b.Currency,
                    Carriers = networkCarrierService.AllAsIEnumerable().Where(d => d.CountryId == b.Id&&d.Id !=54).Select(c => new NetworkCarrierViewModel()
                    {
                        Id = c.Id,
                        NetworkName = c.NetworkName,
                        CarrierIcon = c.CarrierIcon,
                        BasePrice = c.BasePrice.Value
                    })
                })
            };

            return View(viewModel);
        }

        public IActionResult Select(int? id, string page)
        {
            int countryId = 0;
            if (signInManager.IsSignedIn(User))
            {
                countryId = GetCountry();
            }
            UnlockCarrierViewModel viewmodel = new UnlockCarrierViewModel();
            var model = networkCarrierService.GetById(id.Value);
            if (id == 0 || model == null)
            {
                return View(viewmodel);
            }
            viewmodel.BrandId = 0;
            viewmodel.CarrierId = id.Value;
            viewmodel.CountryId = countryId;
            viewmodel.UnlockTypeId = 5;
            viewmodel.TotalPrice = 0;
            viewmodel.CountryId = countryId;

            ViewBag.BrandList = new SelectList(brandService.AllAsIEnumerable().Where(s=>s.Id!=18).Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");

            viewmodel.NetworkCarrier = model;

            return View(viewmodel);
        }

        public JsonResult SetCountry(int id)
        {
            HttpContext.Session.SetString("countryId", id.ToString());
            var asss = HttpContext.Request.Path.Value;
            return Json(true);
        }

        public JsonResult GetCarrier(int CountryId)
        {
            var carrierList = networkCarrierService.AllAsIEnumerable().Where(b => b.CountryId == CountryId&&b.Id!=54).ToList();

            return Json(new SelectList(carrierList, "Id", "NetworkName"));
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
