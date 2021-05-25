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
using Unlockd.Service.Interface;
using Unlockd.Service.Interface.Network;
using Unlockd.Web.Areas.Admin.Models.Network;
using Unlockd.Web.Models;

namespace Unlockd.Web.ViewComponents
{
    public class PhoneUnlockViewComponent : ViewComponent
    {
        private IBrandService brandService;
        public PhoneUnlockViewComponent(IBrandService brandService)
        {
            this.brandService = brandService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var alllist = brandService.AllAsIEnumerable().Where(s=>s.Id!=18);
            return View(alllist);
        }
    }
}
