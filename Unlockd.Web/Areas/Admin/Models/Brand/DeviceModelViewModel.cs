using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Unlockd.Web.Areas.Admin.Models.Brand
{
    public class DeviceModelViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public decimal Charge { get; set; }
        public int BrandId { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}
