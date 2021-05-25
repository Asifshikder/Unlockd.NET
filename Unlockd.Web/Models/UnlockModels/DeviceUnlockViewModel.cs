using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Unlockd.Web.Models.UnlockModels
{
    public class DeviceUnlockViewModel
    {
        public int BrandId { get; set; }
        public int? DeviceModelId { get; set; }
        public int CountryId { get; set; }
        public int NetworkCarrierId { get; set; }
        public string IMEINo { get; set; }
    }
}
