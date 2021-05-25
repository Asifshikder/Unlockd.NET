using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unlockd.Domain.Entities.Pricings;
using Unlockd.Service.Interface;
using Unlockd.Web.Areas.Admin.Models.Pricings;

namespace Unlockd.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class SprintStatusCheckController : Controller
    {
        private ISprintStatusCheckService SprintStatusCheckService;
        private IBrandService brandService;

        public SprintStatusCheckController(
            ISprintStatusCheckService SprintStatusCheckService,
            IBrandService brandService)
        {
            this.SprintStatusCheckService = SprintStatusCheckService;
            this.brandService = brandService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<SprintStatusCheckViewModel> SprintStatuss = new List<SprintStatusCheckViewModel>();
            var entityList = SprintStatusCheckService.AllAsIEnumerable();
            foreach (var item in entityList)
            {
                SprintStatusCheckViewModel SprintStatus = new SprintStatusCheckViewModel();
                SprintStatus.Id = item.Id;
                SprintStatus.BrandId = item.BrandId;
                SprintStatus.BrandName = item.BrandId != 0 ? brandService.GetById(item.BrandId).Name : "";
                SprintStatus.Price = item.Price;
                SprintStatuss.Add(SprintStatus);

            }
            return View(SprintStatuss);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.brandList = new SelectList(brandService.AllAsIEnumerable().Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SprintStatusCheck viewModel)
        {
            SprintStatusCheckService.InsertEntity(viewModel);
            return Redirect("/Admin/SprintStatusCheck/Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.brandList = new SelectList(brandService.AllAsIEnumerable().Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");

            var SprintStatus = SprintStatusCheckService.GetById(id);

            return View(SprintStatus);
        }

        [HttpPost]
        [Route("/Admin/SprintStatusCheck/Update")]
        [AutoValidateAntiforgeryToken]
        public IActionResult Update(SprintStatusCheck viewModel)
        {

            SprintStatusCheckService.UpdateEntity(viewModel);
            return Redirect("/Admin/SprintStatusCheck/index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var SprintStatus = SprintStatusCheckService.GetById(id);
            return View(SprintStatus);
        }

        [HttpPost]
        [Route("/Admin/SprintStatusCheck/DeleteConfirm")]
        [AutoValidateAntiforgeryToken]
        public IActionResult DeleteConfirm(SprintStatusCheck model)
        {
            SprintStatusCheckService.DeleteEntity(model);
            return Redirect("/Admin/SprintStatusCheck/index");
        }

    }
}
