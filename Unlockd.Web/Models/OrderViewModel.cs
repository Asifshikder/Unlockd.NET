using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unlockd.Domain.Entities.Device;
using Unlockd.Domain.Entities.Network;

namespace Unlockd.Web.Models
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public int? BrandId { get; set; }
        public int? DeviceModelId { get; set; }
        public int? NetworkCarrierId { get; set; }
        public int? CountryId { get; set; }
        public int ServiceTypeId { get; set; }

        public int UnlockType { get; set; }
        public string   UnlockTypeName { get; set; }
        public string   ServiceTypeName { get; set; }
        public decimal TotalPrice { get; set; }
        public string IMEI { get; set; }
        public string Email { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }
        public string AddressLine { get; set; }
        public string CityOrTown { get; set; }
        public string StatusName { get; set; }
        public string CountryName { get; set; }
        public string ZipOrPostcode { get; set; }
        public DateTime? OrderTimeUTC { get; set; }
        public  NetworkCarrier NetworkCarrier { get; set; }
        public  string NetworkCarrierName { get; set; }
        public  Brand Brand { get; set; }
        public  string BrandName { get; set; }
        public  DeviceModel DeviceModel { get; set; }
        public  string DeviceModelname { get; set; }
    }
}
