using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Unlockd.Web.Areas.Admin.Models.Pricings
{
    public class ModelVsCarrierViewModel
    {
        public int Id { get; set; }
        public int NetworkCarrierId { get; set; }
        public string CarrierName { get; set; }
        public int DeviceModelId { get; set; }
        public string ModelName { get; set; }
        public string BrandName { get; set; }
        public bool HasPremiumService { get; set; }
        public decimal? BasePrice { get; set; }
        public decimal? PremiumPrice { get; set; }
    }
}
