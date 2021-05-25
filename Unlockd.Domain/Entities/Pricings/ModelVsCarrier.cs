using System;
using System.Collections.Generic;
using System.Text;
using Unlockd.Domain.Entities.Device;
using Unlockd.Domain.Entities.Network;

namespace Unlockd.Domain.Entities.Pricings
{
    public class ModelVsCarrier : BaseEntity
    {
        public int NetworkCarrierId { get; set; }
        public int DeviceModelId { get; set; }
        public bool HasPremiumService { get; set; }
        public decimal? BasePrice { get; set; }
        public decimal? PremiumPrice { get; set; }
        public virtual  NetworkCarrier NetworkCarrier { get; set; }
    }
}
