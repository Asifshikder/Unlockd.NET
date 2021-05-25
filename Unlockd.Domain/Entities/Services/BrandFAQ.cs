using System;
using System.Collections.Generic;
using System.Text;
using Unlockd.Domain.Entities.Device;

namespace Unlockd.Domain.Entities.Services
{
    public class BrandFAQ : BaseEntity
    {
        public string Question { get; set; }
        public string Answer { get; set; }
        public int  SupportMenuId { get; set; }
        public int?  BrandId { get; set; }
        public virtual SupportMenu SupportMenu { get; set; }
        public virtual Brand Brand { get; set; }
    }
}
