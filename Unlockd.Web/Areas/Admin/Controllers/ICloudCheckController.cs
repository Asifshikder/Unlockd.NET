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
    public class ICloudCheckController : Controller
    {
        private IICloudCheckService ICloudCheckService;
        private IBrandService brandService;

        public ICloudCheckController(
            IICloudCheckService ICloudCheckService,
            IBrandService brandService)
        {
            this.ICloudCheckService = ICloudCheckService;
            this.brandService = brandService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<ICloudCheckViewModel> IClouds = new List<ICloudCheckViewModel>();
            var entityList = ICloudCheckService.AllAsIEnumerable();
            foreach (var item in entityList)
            {
                ICloudCheckViewModel ICloud = new ICloudCheckViewModel();
                ICloud.Id = item.Id;
                ICloud.BrandId = item.BrandId;
                ICloud.BrandName = item.BrandId != 0 ? brandService.GetById(item.BrandId).Name : "";
                ICloud.Price = item.Price;
                IClouds.Add(ICloud);

            }
            return View(IClouds);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.brandList = new SelectList(brandService.AllAsIEnumerable().Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ICloudCheck viewModel)
        {
            ICloudCheckService.InsertEntity(viewModel);
            return Redirect("/Admin/ICloudCheck/Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.brandList = new SelectList(brandService.AllAsIEnumerable().Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");

            var ICloud = ICloudCheckService.GetById(id);

            return View(ICloud);
        }

        [HttpPost]
        [Route("/Admin/ICloudCheck/Update")]
        [AutoValidateAntiforgeryToken]
        public IActionResult Update(ICloudCheck viewModel)
        {

            ICloudCheckService.UpdateEntity(viewModel);
            return Redirect("/Admin/ICloudCheck/index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var ICloud = ICloudCheckService.GetById(id);
            return View(ICloud);
        }

        [HttpPost]
        [Route("/Admin/ICloudCheck/DeleteConfirm")]
        [AutoValidateAntiforgeryToken]
        public IActionResult DeleteConfirm(ICloudCheck model)
        {
            ICloudCheckService.DeleteEntity(model);
            return Redirect("/Admin/ICloudCheck/index");
        }

    }
}
