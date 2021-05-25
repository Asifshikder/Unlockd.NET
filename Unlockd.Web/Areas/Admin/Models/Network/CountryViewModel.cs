using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unlockd.Domain.Entities.Network;

namespace Unlockd.Web.Areas.Admin.Models.Network
{
    public class CountryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string FlagIcon { get; set; }
        public string Currency { get; set; }
        public IEnumerable<NetworkCarrierViewModel> Carriers { get; set; }
        public IFormFile FlagIconFile { get; set; }
    }
}
