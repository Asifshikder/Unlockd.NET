using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Unlockd.Web.Areas.Admin.Models.Pricings
{
    public class ICloudCheckViewModel
    {
        public int Id { get; set; }
        public string BrandName { get; set; }
        public decimal? Price { get; set; }
        public int BrandId { get; set; }

    }
}
