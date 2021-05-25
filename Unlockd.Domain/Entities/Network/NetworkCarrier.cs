using System;
using System.Collections.Generic;
using System.Text;
using Unlockd.Domain.Entities.Pricings;
using Unlockd.Domain.Entities.SalesAndOrder;

namespace Unlockd.Domain.Entities.Network
{
   public class NetworkCarrier : BaseEntity
    {
        public NetworkCarrier()
        {
            Orders = new HashSet<Order>();
            ModelVsCarrier = new HashSet<ModelVsCarrier>();
        }
        public string NetworkName { get; set; }
        public string CarrierIcon { get; set; }
        public string CarrierImage { get; set; }
        public string CovorPhoto { get; set; }
        public string Description { get; set; }
        public decimal? BasePrice { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<ModelVsCarrier> ModelVsCarrier { get; set; }
    }
}
