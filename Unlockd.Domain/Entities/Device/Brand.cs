using System;
using System.Collections.Generic;
using System.Text;
using Unlockd.Domain.Entities.Pricings;
using Unlockd.Domain.Entities.Services;

namespace Unlockd.Domain.Entities.Device
{
    public class Brand : BaseEntity
    {
        public Brand()
        {
            DeviceModel = new HashSet<DeviceModel>();
            BrandFAQ= new HashSet<BrandFAQ>();
            CarrierCheck = new HashSet<CarrierCheck>();
            BlackListCheck = new HashSet<BlackListCheck>();
            ICloudCheck = new HashSet<ICloudCheck>();
            SprintStatusCheck = new HashSet<SprintStatusCheck>();
        }
        public string Name { get; set; }
        public string BrandLogo { get; set; }
        public bool IsFeatured { get; set; } = false;
        public string FeaturedImage { get; set; }
        public string CovorPhoto { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public decimal AverageUnlockingPrice { get; set; }
        public virtual ICollection<DeviceModel> DeviceModel { get; set; }
        public virtual ICollection<BrandFAQ> BrandFAQ { get; set; }
        public virtual ICollection<CarrierCheck> CarrierCheck { get; set; }
        public virtual ICollection<BlackListCheck> BlackListCheck { get; set; }
        public virtual ICollection<ICloudCheck> ICloudCheck { get; set; }
        public virtual ICollection<SprintStatusCheck> SprintStatusCheck { get; set; }

    }
}
