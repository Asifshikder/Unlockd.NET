using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unlockd.Service.Interface.Network;

namespace Unlockd.Web.ViewComponents
{
    public class FooterViewComponent:ViewComponent
    {
        private ICountryService countryService;

        public FooterViewComponent(ICountryService countryService)
        {
            this.countryService = countryService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var countrylist = countryService.AllAsIEnumerable();
            return View(countrylist);
        }
    }
}
