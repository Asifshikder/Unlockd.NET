using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Threading.Tasks;
using Unlockd.Domain.Entities.Network;
using Unlockd.Service.Interface.Network;
using Unlockd.Web.Areas.Admin.Models.Network;
using Unlockd.Web.Models;

namespace Unlockd.Web.ViewComponents
{
    public class TopAreaViewComponent : ViewComponent
    {
        private ICountryService countryService;
        public TopAreaViewComponent(ICountryService countryService)
        {
            this.countryService = countryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            int id;
            if (HttpContext.Session.GetString("countryId") == null)
            {
                id = countryService.FirstOrDefault().Id;
                HttpContext.Session.SetString("countryId", id.ToString());
            }
            id = Int32.Parse(HttpContext.Session.GetString("countryId"));
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
    }
}
