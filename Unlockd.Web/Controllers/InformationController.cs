using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unlockd.Service.Interface;
using Unlockd.Service.Interface.Device;
using Unlockd.Service.Interface.Network;
using Unlockd.Web.Models.UnlockModels;

namespace Unlockd.Web.Controllers
{
    public class InformationController : Controller
    {
        private ICarrierCheckService carrierCheckService;
        private IBlackListCheckService blackListCheckService;
        private IICloudCheckService iCloudCheckService;
        private ISprintStatusCheckService sprintStatusCheckService;
        private IModelVsCarrierService modelVsCarrierService;
        private IBrandService brandService;
        private INetworkCarrierService networkCarrierService;
        private IDeviceModelService deviceModelService;

        public InformationController(ICarrierCheckService carrierCheckService,
            IBlackListCheckService blackListCheckService,
            IICloudCheckService iCloudCheckService,
            ISprintStatusCheckService sprintStatusCheckService,
            IModelVsCarrierService modelVsCarrierService,
            IBrandService brandService,
            INetworkCarrierService networkCarrierService,
            IDeviceModelService deviceModelService
            )
        {
            this.carrierCheckService = carrierCheckService;
            this.blackListCheckService = blackListCheckService;
            this.iCloudCheckService = iCloudCheckService;
            this.sprintStatusCheckService = sprintStatusCheckService;
            this.modelVsCarrierService = modelVsCarrierService;
            this.brandService = brandService;
            this.networkCarrierService = networkCarrierService;
            this.deviceModelService = deviceModelService;
        }
        public JsonResult GetModelInfo(int modelId)
        {
            ModelInfo model = new ModelInfo();
            if (modelId == 0)
                return Json(model);
            var info = deviceModelService.GetById(modelId);
            if (info != null)
            {
                var imageurl = info.Image.Replace("~/", "/");
                model.Id = info.Id;
                model.Name = info.Name;
                model.Image = imageurl.Trim();
            }
            return Json(model);
        }
        public JsonResult GetCarrierInfo(int modelId)
        {
            ModelInfo model = new ModelInfo();
            if (modelId == 0)
                return Json(model);
            var info = networkCarrierService.GetById(modelId);
            if (info != null)
            {
                var imageurl = info.CarrierIcon.Replace("~/", "/");
                model.Id = info.Id;
                model.Name = info.NetworkName;
                model.Image = imageurl.Trim();
            }
            return Json(model);
        }
    }
}
