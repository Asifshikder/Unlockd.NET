using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Unlockd.Web.Models
{
    public class PhoneCheckPreviewModel
    {
        public string Image { get; set; }
        public string BrandName { get; set; }
        public bool IsAvailable { get; set; }
        public decimal Price { get; set; }
        public decimal? PremiumPrice { get; set; }
        public bool? HasPremium { get; set; }
    }
}
