using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unlockd.Domain.Entities.SalesAndOrder;

namespace Unlockd.Web.Areas.Admin.Models.Orders
{
    public class OrderViewModel
    {

        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public string DeviceModelName { get; set; }
        public string BrandName { get; set; }
        public int BrandId { get; set; }
        public string NetworkCarrierName { get; set; }
        public string CountryName { get; set; }
        public int UnlockType { get; set; }
        public string UnlockTypeName { get; set; }
        public decimal TotalPrice { get; set; }
        public string IMEI { get; set; }
        public string Email { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }
        public string FullName { get; set; }
        public string AddressLine { get; set; }
        public string CityOrTown { get; set; }
        public string ZipOrPostcode { get; set; }
        public bool IsRead { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public string OrderStatusName { get; set; }
        public string PaymentStatus { get; set; }
    }
}
