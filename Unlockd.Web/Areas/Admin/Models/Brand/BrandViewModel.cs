using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unlockd.Domain.Entities.Device;

namespace Unlockd.Web.Areas.Admin.Models.Brand
{
    public class BrandViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BrandLogo { get; set; }
        public string CovorPhoto { get; set; }
        public string FeaturedImage { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public decimal AverageUnlockingPrice { get; set; }
        public IEnumerable<DeviceModel> Devices { get; set; }
        public IFormFile BrandLogofile { get; set; }
        public IFormFile FeaturedImageFile { get; set; }
        public IFormFile CovorPhotoFile { get; set; }
    }
}
