using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unlockd.Domain.Entities.Device;
using Unlockd.Domain.Entities.Services;
using Unlockd.Web.Areas.Admin.Models.Blog;
using Unlockd.Web.Areas.Admin.Models.Brand;
using Unlockd.Web.Areas.Admin.Models.Network;
using Unlockd.Web.Areas.Admin.Models.Testimonials;

namespace Unlockd.Web.Models
{
    public class HomeContentsViewModel
    {
        public IEnumerable<BrandViewModel> Brands { get; set; }
        public IEnumerable<Brand> Brandlist { get; set; }
        public IEnumerable<FAQ> FAQs { get; set; }
        public IEnumerable<TestimonialViewModel> Testimonials { get; set; }
        public IEnumerable<BlogPostViewModel> BlogPosts { get; set; }
        public IEnumerable<NetworkCarrierViewModel> NetworkCarriers { get; set; }
    }
}
