using System;
using System.Collections.Generic;
using System.Text;

namespace Unlockd.Domain.Entities.Services
{
    public class SupportMenu : BaseEntity
    {
        public SupportMenu()
        {
            BrandFAQ = new HashSet<BrandFAQ>();
        }
        public string MenuIcon { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? IsIncluded { get; set; }
        public virtual ICollection<BrandFAQ> BrandFAQ { get; set; }

    }
}
