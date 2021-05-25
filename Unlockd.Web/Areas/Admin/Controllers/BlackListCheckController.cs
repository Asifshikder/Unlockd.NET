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
    public class BlackListCheckController : Controller
    {
        private IBlackListCheckService blackListCheckService;
        private IBrandService brandService;

        public BlackListCheckController(
            IBlackListCheckService blackListCheckService,
            IBrandService brandService)
        {
            this.blackListCheckService = blackListCheckService;
            this.brandService = brandService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<BlackListCheckViewModel> blackLists = new List<BlackListCheckViewModel>();
            var entityList = blackListCheckService.AllAsIEnumerable();
            foreach (var item in entityList)
            {
                BlackListCheckViewModel blackList = new BlackListCheckViewModel();
                blackList.Id = item.Id;
                blackList.BrandId = item.BrandId;
                blackList.BrandName = item.BrandId != 0 ? brandService.GetById(item.BrandId).Name : "";
                blackList.Price = item.Price;
                blackLists.Add(blackList);

            }
            return View(blackLists);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.brandList = new SelectList(brandService.AllAsIEnumerable().Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(BlackListCheck viewModel)
        {
            blackListCheckService.InsertEntity(viewModel);
            return Redirect("/Admin/BlackListCheck/Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.brandList = new SelectList(brandService.AllAsIEnumerable().Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");

            var blackList = blackListCheckService.GetById(id);

            return View(blackList);
        }

        [HttpPost]
        [Route("/Admin/BlackListCheck/Update")]
        [AutoValidateAntiforgeryToken]
        public IActionResult Update(BlackListCheck viewModel)
        {

            blackListCheckService.UpdateEntity(viewModel);
            return Redirect("/Admin/BlackListCheck/index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var BlackList = blackListCheckService.GetById(id);
            return View(BlackList);
        }

        [HttpPost]
        [Route("/Admin/BlackListCheck/DeleteConfirm")]
        [AutoValidateAntiforgeryToken]
        public IActionResult DeleteConfirm(BlackListCheck model)
        {
            blackListCheckService.DeleteEntity(model);
            return Redirect("/Admin/BlackListCheck/index");
        }

    }
}
