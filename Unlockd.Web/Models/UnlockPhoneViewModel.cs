using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unlockd.Domain.Entities.Device;
using Unlockd.Domain.Entities.Services;

namespace Unlockd.Web.Models
{
    public class UnlockPhoneViewModel
    {

        public Brand Brand { get; set; }
        public DeviceModel DeviceModel { get; set; }
        public List<DeviceModel> DeviceModels { get; set; }
        public List<BrandFAQ> BrandFAQs { get; set; }
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
