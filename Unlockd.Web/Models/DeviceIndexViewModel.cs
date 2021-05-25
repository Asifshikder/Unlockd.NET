using System;
using System.Collections.Generic;
using Unlockd.Domain.Entities.SalesAndOrder;
using Unlockd.Web.Areas.Admin.Models.Brand;

namespace Unlockd.Web.Models
{
    public class DeviceIndexViewModel
    {
        public Order Order { get; set; }
        public IEnumerable<BrandViewModel> Brands { get; set; }
    }
}
