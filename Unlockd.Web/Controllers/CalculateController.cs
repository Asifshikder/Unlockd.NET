using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unlockd.Service.Interface;
using Unlockd.Web.Models;

namespace Unlockd.Web.Controllers
{
    public class CalculateController : Controller
    {
        private IModelVsCarrierService modelVsCarrierService;
        private IBrandService brandService;
        private ICarrierCheckService carrierCheckService;
        private IBlackListCheckService blackListCheckService;
        private IICloudCheckService iCloudCheckService;
        private ISprintStatusCheckService sprintStatusCheckService;

        public CalculateController(ICarrierCheckService carrierCheckService,
            IBlackListCheckService blackListCheckService,
            IICloudCheckService iCloudCheckService,
            ISprintStatusCheckService sprintStatusCheckService,
            IModelVsCarrierService modelVsCarrierService,
            IBrandService brandService
            )
        {
            this.carrierCheckService = carrierCheckService;
            this.blackListCheckService = blackListCheckService;
            this.iCloudCheckService = iCloudCheckService;
            this.sprintStatusCheckService = sprintStatusCheckService;
            this.modelVsCarrierService = modelVsCarrierService;
            this.brandService = brandService;
        }
        public JsonResult GetCarrierCheck(int BrandId)
        {
            PhoneCheckPreviewModel model = new PhoneCheckPreviewModel();
            if (BrandId == 0)
                return Json(model);
            var info = carrierCheckService.AllAsIEnumerable().Where(b => b.BrandId == BrandId).FirstOrDefault();
            var brand = brandService.GetById(BrandId);
            if (info == null)
            {
                var imageurl = brand.BrandLogo.Replace("~/", "/");
                model.Price = 0;
                model.IsAvailable = false;
                model.Image = imageurl.Trim();
                model.BrandName = brand.Name;
            }
            else
            {
                var imageurl = brand.BrandLogo.Replace("~/", "/");
                model.Price = info.Price;
                model.IsAvailable = true;
                model.Image = imageurl.Trim();
                model.BrandName = brand.Name;
            }
            return Json(model);
        }
        public JsonResult GetBlackListCheck(int BrandId)
        {
            PhoneCheckPreviewModel model = new PhoneCheckPreviewModel();
            if (BrandId == 0)
                return Json(model);
            var info = blackListCheckService.AllAsIEnumerable().Where(b => b.BrandId == BrandId).FirstOrDefault();
            var brand = brandService.GetById(BrandId);
            if (info == null)
            {
                var imageurl = brand.BrandLogo.Replace("~/", "/");
                model.Price = 0;
                model.IsAvailable = false;
                model.Image = imageurl.Trim();
                model.BrandName = brand.Name;
            }
            else
            {
                var imageurl = brand.BrandLogo.Replace("~/", "/");
                model.Price = info.Price;
                model.IsAvailable = true;
                model.Image = imageurl.Trim();
                model.BrandName = brand.Name;
            }
            return Json(model);
        }
        public JsonResult GetSprintCheck(int BrandId)
        {
            PhoneCheckPreviewModel model = new PhoneCheckPreviewModel();
            if (BrandId == 0)
                return Json(model);
            var info = sprintStatusCheckService.AllAsIEnumerable().Where(b => b.BrandId == BrandId).FirstOrDefault();
            var brand = brandService.GetById(BrandId);
            if (info == null)
            {
                var imageurl = brand.BrandLogo.Replace("~/", "/");
                model.Price = 0;
                model.IsAvailable = false;
                model.Image = imageurl.Trim();
                model.BrandName = brand.Name;
            }
            else
            {
                var imageurl = brand.BrandLogo.Replace("~/", "/");
                model.Price = info.Price;
                model.IsAvailable = true;
                model.Image = imageurl.Trim();
                model.BrandName = brand.Name;
            }
            return Json(model);
        }
        public JsonResult GetIcloudCheck(int BrandId)
        {
            PhoneCheckPreviewModel model = new PhoneCheckPreviewModel();
            if (BrandId == 0)
                return Json(model);
            var info = iCloudCheckService.AllAsIEnumerable().Where(b => b.BrandId == BrandId).FirstOrDefault();
            var brand = brandService.GetById(BrandId);
            if (info == null)
            {
                var imageurl = brand.BrandLogo.Replace("~/", "/");
                model.Price = 0;
                model.IsAvailable = false;
                model.Image = imageurl.Trim();
                model.BrandName = brand.Name;
            }
            else
            {
                var imageurl = brand.BrandLogo.Replace("~/", "/");
                model.Price = info.Price;
                model.IsAvailable = true;
                model.Image = imageurl.Trim();
                model.BrandName = brand.Name;
            }
            return Json(model);
        }


        public JsonResult CalculateCarrierPrice(int CarrierId, int ModelId)
        {
            PhoneCheckPreviewModel model = new PhoneCheckPreviewModel();
            if (ModelId == 0 || CarrierId == 0)
                return Json(model);
            var info = modelVsCarrierService.AllAsIEnumerable().Where(b => b.NetworkCarrierId == CarrierId && b.DeviceModelId==ModelId).FirstOrDefault();
          
            if (info == null)
            {
                model.Price = 0;
                model.IsAvailable = false;
            }
            else
            {
                model.Price = info.BasePrice.Value;
                model.IsAvailable = true;
                model.HasPremium = info.HasPremiumService;
                model.PremiumPrice = info.PremiumPrice;
            }
            return Json(model);
        }
    }
}

