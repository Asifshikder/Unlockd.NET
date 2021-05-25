using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unlockd.Domain.Entities.Services;
using Unlockd.Web.Areas.Admin.Models.Blog;
using Unlockd.Web.Areas.Admin.Models.Brand;
using Unlockd.Web.Areas.Admin.Models.Network;
using Unlockd.Web.Areas.Admin.Models.Testimonials;

namespace Unlockd.Web.Models
{
    public class CarrierIndexViewModel
    {
        public CountryViewModel Country { get; set; }
        public IEnumerable<CountryViewModel> Countries { get; set; }
    }
}
