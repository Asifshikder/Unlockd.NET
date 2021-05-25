using System;
using System.Collections.Generic;
using System.Text;
using Unlockd.Domain.Entities.Pricings;
using Unlockd.Domain.Entities.SalesAndOrder;

namespace Unlockd.Domain.Entities.Device
{
    public class DeviceModel : BaseEntity
    {
        public DeviceModel()
        {
            Orders = new HashSet<Order>();
        }
        public string Name { get; set; }
        public string Image { get; set; }
        public bool IsFeatured { get; set; } = false;
        public decimal? Charge { get; set; }
        public int BrandId { get; set; }
        public virtual Brand Brand { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
