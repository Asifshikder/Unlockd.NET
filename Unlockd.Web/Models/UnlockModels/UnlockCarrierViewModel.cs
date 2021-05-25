using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unlockd.Domain.Entities.Network;

namespace Unlockd.Web.Models.UnlockModels
{
    public class UnlockCarrierViewModel
    {
        public NetworkCarrier NetworkCarrier { get; set; }
        public int UnlockTypeId { get; set; }
        public int BrandId { get; set; }
        public string IMEI { get; set; }
        public int? DeviceModelId { get; set; }
        public int? CarrierId { get; set; }
        public int? CountryId { get; set; }
        public decimal TotalPrice { get; set; }
        public bool? ServiceType { get; set; }
    }
}
