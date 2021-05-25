using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Unlockd.Web.Models
{
    public class BrandFAQViewModel
    {
        public int SupportMenuId { get; set; }
        public string Name { get; set; }
        public string Desciption { get; set; }
        public IList<FAQViewModel> FAQs { get; set; }
    }
    
    public class FAQViewModel
    {
        public int FAQID { get; set; }
        public string Question  { get; set; }
        public string Answer { get; set; }
    }

}
