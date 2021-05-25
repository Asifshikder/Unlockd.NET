using System;
using System.Collections.Generic;
using System.Text;
using Unlockd.Domain.Entities.Device;
using Unlockd.Domain.Entities.Network;

namespace Unlockd.Domain.Entities.SalesAndOrder
{
    public class Order : BaseEntity
    {
        public int BrandId { get; set; }
        public int? DeviceModelId { get; set; }
        public int? NetworkCarrierId { get; set; }
        public int? CountryId { get; set; }
        public int UnlockType { get; set; }
        public int ServiceTypeId { get; set; }
        public decimal TotalPrice { get; set; }
        public string IMEI { get; set; }
        public string Email { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }
        public string AddressLine { get; set; }
        public string CityOrTown { get; set; }
        public string ZipOrPostcode { get; set; }
        public DateTime? OrderTimeUTC { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public virtual NetworkCarrier NetworkCarrier { get; set; }
    }
    public enum OrderStatus
    {
        Pending = 1,
        Accepted,
        Processing,
        Completed,
        Refunded,
        Cancel
    }
}
