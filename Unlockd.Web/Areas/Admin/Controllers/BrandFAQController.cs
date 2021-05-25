using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using Unlockd.Domain.Entities.Services;
using Unlockd.Service.Interface.Services;

namespace Unlockd.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class BrandFAQController : Controller
    {
        private IBrandFAQService BrandFAQService;
        private ISupportMenuService SupportMenuService;

        public BrandFAQController(IBrandFAQService BrandFAQService, ISupportMenuService SupportMenuService)
        {
            this.BrandFAQService = BrandFAQService;
            this.SupportMenuService = SupportMenuService;
        }
        [HttpGet]
        public IActionResult Index(int id)
        {
            var entityList = BrandFAQService.AllAsIEnumerable().Where(s => s.SupportMenuId == id).ToList();
            ViewBag.supportid = id;
            return View(entityList);
        }
        [HttpGet]
        public IActionResult Create(int id)
        {
            BrandFAQ fAQ = new BrandFAQ
            {
                SupportMenuId = id
            };
            return View(fAQ);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(BrandFAQ BrandFAQ)
        {
            BrandFAQ.Id = 0;
            BrandFAQService.InsertEntity(BrandFAQ);
            return Redirect("/Admin/BrandFAQ/Index?id=" + BrandFAQ.SupportMenuId + "");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.catlist = new SelectList(SupportMenuService.AllAsIEnumerable().Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");

            BrandFAQ model = BrandFAQService.GetById(id);

            return View(model);
        }
        [HttpPost]
        [Route("/Admin/BrandFAQ/Update")]
        [AutoValidateAntiforgeryToken]
        public IActionResult Update(BrandFAQ BrandFAQ)
        {
            BrandFAQService.UpdateEntity(BrandFAQ);
            return Redirect("/Admin/BrandFAQ/Index?id=" + BrandFAQ.SupportMenuId + "");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            BrandFAQ BrandFAQ = BrandFAQService.GetById(id);
            return View(BrandFAQ);
        }
        [HttpPost]
        [Route("/Blog/BrandFAQ/DeleteConfirm")]
        [AutoValidateAntiforgeryToken]
        public IActionResult DeleteConfirm(BrandFAQ BrandFAQ)
        {
            int returnId = BrandFAQ.SupportMenuId;
            BrandFAQService.DeleteEntity(BrandFAQ);
            return Redirect("/Blog/BrandFAQ/Index?id=" + returnId + "");
        }
    }
}
