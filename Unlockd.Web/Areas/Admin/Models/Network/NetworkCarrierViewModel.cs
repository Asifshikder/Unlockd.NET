using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unlockd.Domain.Entities.Network;

namespace Unlockd.Web.Areas.Admin.Models.Network
{
    public class NetworkCarrierViewModel
    {
        public int Id { get; set; }
        public string NetworkName { get; set; }
        public string CarrierIcon { get; set; }
        public string CovorPhoto { get; set; }
        public string Description { get; set; }
        public decimal BasePrice { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public IFormFile CarrierIconFile { get; set; }
        public IFormFile CovorPhotoFile { get; set; }
    }
}
