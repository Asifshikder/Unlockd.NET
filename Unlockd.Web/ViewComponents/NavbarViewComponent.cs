using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unlockd.Domain.Entities.Auth;
using Unlockd.Service.Interface.Network;
using Unlockd.Web.Areas.Admin.Models.Network;
using Unlockd.Web.Models;

namespace Unlockd.Web.ViewComponents
{
    public class NavbarViewComponent:ViewComponent
    {
        private UserManager<User> userManager;
        private SignInManager<User> signInManager;
        private ICountryService countryService;

        public NavbarViewComponent(ICountryService countryService,UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.countryService = countryService;

        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
           
            int id;
            var user = GetCurrentUser().Result;
            if (user != null)
            {
                id = user.CountryId.Value;
            }
            else
            {
                id = countryService.FirstOrDefault().Id;
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
                    Currency = country.Currency
                },

                Countries = countries.Select(b => new CountryViewModel()
                {
                    Id = b.Id,
                    Name = b.Name,
                    DisplayName = b.DisplayName,
                    FlagIcon = b.FlagIcon,
                    Currency = b.Currency
                })
            };

            return View(viewModel);
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
