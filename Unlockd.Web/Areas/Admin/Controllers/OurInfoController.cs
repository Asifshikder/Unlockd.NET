using Microsoft.AspNetCore.Mvc;
using Unlockd.Service.Interface.Services;
using Unlockd.Domain.Entities.Services;
using Microsoft.AspNetCore.Authorization;

namespace Unlockd.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class OurInfoController : Controller
    {
        private IOurInfoService _ourInfoService;


        public OurInfoController(IOurInfoService ourInfoService)
        {
            this._ourInfoService = ourInfoService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var entityList = _ourInfoService.AllAsIEnumerable();
            return View(entityList);
        }
        [HttpGet]
        public IActionResult Create()
        {
            OurInfo OurInfo = new OurInfo();
            return View(OurInfo);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(OurInfo OurInfo)
        {
            _ourInfoService.InsertEntity(OurInfo);
            return Redirect("/Admin/OurInfo/Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            OurInfo OurInfo = _ourInfoService.GetById(id);
            return View(OurInfo);
        }
        [HttpPost]
        [Route("/Admin/OurInfo/Update")]
        [AutoValidateAntiforgeryToken]
        public IActionResult Update(OurInfo OurInfo)
        {
            _ourInfoService.UpdateEntity(OurInfo);
            return Redirect("/Admin/OurInfo/index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            OurInfo OurInfo = _ourInfoService.GetById(id);
            return View(OurInfo);
        }
        [HttpPost]
        [Route("/Admin/OurInfo/DeleteConfirm")]
        [AutoValidateAntiforgeryToken]
        public IActionResult DeleteConfirm(OurInfo OurInfo)
        {
            _ourInfoService.DeleteEntity(OurInfo);
            return Redirect("/Admin/OurInfo/index");
        }
    }
}
