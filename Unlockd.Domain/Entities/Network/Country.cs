using System;
using System.Collections.Generic;
using System.Text;
using Unlockd.Domain.Entities.SalesAndOrder;
using Unlockd.Domain.Entities.Services;

namespace Unlockd.Domain.Entities.Network
{
  public  class Country : BaseEntity
    {
        public Country()
        {
            NetworkCarriers = new HashSet<NetworkCarrier>();
            Orders = new HashSet<Order>();
        }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string FlagIcon { get; set; }
        public string Currency { get; set; }
        public virtual ICollection<NetworkCarrier> NetworkCarriers { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
