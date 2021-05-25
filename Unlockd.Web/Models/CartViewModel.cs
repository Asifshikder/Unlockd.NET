using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Unlockd.Web.Models
{
    public class CartViewModel
    {
        public int UnlockTypeId { get; set; }
        public int BrandId { get; set; }
        public string IMEI { get; set; }
        public int? DeviceModelId { get; set; }
        public int? CarrierId { get; set; }
        public int? CountryId { get; set; }
        public decimal TotalPrice { get; set; }
        public bool? ServiceType { get; set; }
        public string ServiceTypeName { get; set; }
        public int? radioService { get; set; }
    }
    
}
