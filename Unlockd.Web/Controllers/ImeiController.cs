using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unlockd.Service.Interface.Orders;

namespace Unlockd.Web.Controllers
{
    [Authorize]
    public class ImeiController : Controller
    {
        private IImeiCheck imeiCheck;

        public ImeiController(IImeiCheck imeiCheck)
        {
            this.imeiCheck = imeiCheck;
        }
        [HttpGet]
        public JsonResult Check(string imei)
        {
            long imeinum = Convert.ToInt64(imei);
            return Json(imeiCheck.ImeiCheck(imeinum));
        }
    }
}
