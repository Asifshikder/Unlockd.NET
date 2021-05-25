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
    public class CarrierCheckController : Controller
    {
        private ICarrierCheckService CarrierCheckService;
        private IBrandService brandService;

        public CarrierCheckController(
            ICarrierCheckService CarrierCheckService,
            IBrandService brandService)
        {
            this.CarrierCheckService = CarrierCheckService;
            this.brandService = brandService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<CarrierCheckViewModel> Carriers = new List<CarrierCheckViewModel>();
            var entityList = CarrierCheckService.AllAsIEnumerable();
            foreach (var item in entityList)
            {
                CarrierCheckViewModel Carrier = new CarrierCheckViewModel();
                Carrier.Id = item.Id;
                Carrier.BrandId = item.BrandId;
                Carrier.BrandName = item.BrandId != 0 ? brandService.GetById(item.BrandId).Name : "";
                Carrier.Price = item.Price;
                Carriers.Add(Carrier);

            }
            return View(Carriers);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.brandList = new SelectList(brandService.AllAsIEnumerable().Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CarrierCheck viewModel)
        {
            CarrierCheckService.InsertEntity(viewModel);
            return Redirect("/Admin/CarrierCheck/Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.brandList = new SelectList(brandService.AllAsIEnumerable().Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");

            var Carrier = CarrierCheckService.GetById(id);

            return View(Carrier);
        }

        [HttpPost]
        [Route("/Admin/CarrierCheck/Update")]
        [AutoValidateAntiforgeryToken]
        public IActionResult Update(CarrierCheck viewModel)
        {

            CarrierCheckService.UpdateEntity(viewModel);
            return Redirect("/Admin/CarrierCheck/index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var Carrier = CarrierCheckService.GetById(id);
            return View(Carrier);
        }

        [HttpPost]
        [Route("/Admin/CarrierCheck/DeleteConfirm")]
        [AutoValidateAntiforgeryToken]
        public IActionResult DeleteConfirm(CarrierCheck model)
        {
            CarrierCheckService.DeleteEntity(model);
            return Redirect("/Admin/CarrierCheck/index");
        }

    }
}
