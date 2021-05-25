using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Unlockd.Domain.Entities.Services;
using Unlockd.Service.Interface.Services;

namespace Unlockd.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class FAQController : Controller
    {
        private IFAQService faqService;
       

        public FAQController(IFAQService faqService)
        {
            this.faqService = faqService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var entityList = faqService.AllAsIEnumerable();
            return View(entityList);
        }
        [HttpGet]
        public IActionResult Create()
        {
            FAQ fAQ = new FAQ();
            return View(fAQ);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(FAQ fAQ)
        {
            faqService.InsertEntity(fAQ);
            return Redirect("/Admin/faq/Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            FAQ fAQ = faqService.GetById(id);
            return View(fAQ);
        }
        [HttpPost]
        [Route("/Admin/faq/Update")]
        [AutoValidateAntiforgeryToken]
        public IActionResult Update(FAQ fAQ)
        {
            faqService.UpdateEntity(fAQ);
            return Redirect("/Admin/faq/index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            FAQ fAQ = faqService.GetById(id);
            return View(fAQ);
        }
        [HttpPost]
        [Route("/Admin/faq/DeleteConfirm")]
        [AutoValidateAntiforgeryToken]
        public IActionResult DeleteConfirm(FAQ fAQ)
        {
            faqService.DeleteEntity(fAQ);
            return Redirect("/Admin/faq/index");
        }
    }
}