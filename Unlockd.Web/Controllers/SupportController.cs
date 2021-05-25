using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unlockd.Service.Interface.Services;
using Unlockd.Web.Models;

namespace Unlockd.Web.Controllers
{
    [Authorize]
    public class SupportController : Controller
    {
        private IBrandFAQService brandFAQService;
        private ISupportMenuService supportMenuService;

        public SupportController(ISupportMenuService supportMenuService,IBrandFAQService brandFAQService)
        {
            this.brandFAQService = brandFAQService;
            this.supportMenuService = supportMenuService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var listofmenu = supportMenuService.AllAsIEnumerable();
            return View(listofmenu);
        }
        public IActionResult ByName(int id)
        {
            BrandFAQViewModel model = new BrandFAQViewModel();
            List<FAQViewModel> models = new List<FAQViewModel>();
            var menu = supportMenuService.GetById(id);
            var listoffaq = brandFAQService.AllAsIEnumerable().Where(s => s.SupportMenuId == menu.Id).ToList();
            foreach(var item in listoffaq)
            {
                FAQViewModel fAQ = new FAQViewModel();
                fAQ.FAQID = item.Id;
                fAQ.Question = item.Question;
                fAQ.Answer = item.Answer;
                models.Add(fAQ);
            }
            model.SupportMenuId = menu.Id;
            model.Name = menu.Name;
            model.Desciption = menu.Description;
            model.FAQs = models;
            return View(model);
        }
    }
}
