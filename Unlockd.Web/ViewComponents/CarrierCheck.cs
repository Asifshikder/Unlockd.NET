using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unlockd.Domain.Entities.Device;
using Unlockd.Service.Interface;
using Unlockd.Web.Models;

namespace Unlockd.Web.ViewComponents
{
    public class CarrierCheckViewComponent : ViewComponent
    {
        private IBrandService brandService;

        public CarrierCheckViewComponent(IBrandService brandService)
        {
            this.brandService = brandService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var BrandList = brandService.AllAsIEnumerable().Where(s => s.Id != 18).ToList();
            BrandList.Insert(0, new Brand { Id = 0, Name = "Select" });
            ViewBag.BrandList = BrandList;
            CartViewModel cart = new CartViewModel()
            {
                TotalPrice = 0,
                UnlockTypeId = 1
            };

            return View(cart);
        }
    }
}
