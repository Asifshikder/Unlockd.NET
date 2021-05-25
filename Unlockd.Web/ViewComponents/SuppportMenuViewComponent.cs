using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unlockd.Service.Interface.Services;

namespace Unlockd.Web.ViewComponents
{
    public class SupportMenuViewComponent:ViewComponent
    {
        private ISupportMenuService supportMenuService;

        public SupportMenuViewComponent(ISupportMenuService supportMenuService)
        {
            this.supportMenuService = supportMenuService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = supportMenuService.AllAsIEnumerable();
            return View(model);
        }
    }
}
