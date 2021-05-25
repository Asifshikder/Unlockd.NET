using System;
using System.Collections.Generic;
using System.Text;
using Unlockd.Domain.Entities.Device;

namespace Unlockd.Domain.Entities.Pricings
{
  public  class BlackListCheck : BaseEntity
    {
        public int BrandId { get; set; }
        public decimal Price { get; set; }
        public virtual Brand Brand { get; set; }
    }
}
