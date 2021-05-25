using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Unlockd.Web.Areas.Admin.Models.Orders
{
    public class OrderListViewModel
    {
        public int Id { get; internal set; }
        public string DeviceModelName { get; internal set; }
        public string BrandName { get; internal set; }
        public string NetworkCarrierName { get; internal set; }
        public string CountryName { get; internal set; }
        public string UnlockTypeName { get; internal set; }
        public decimal TotalPrice { get; internal set; }
        public string OrderStatusName { get; internal set; }
        public string Surname { get; internal set; }
        public string IMEI { get; internal set; }
        public string Email { get; internal set; }
        public string Forename { get; internal set; }
        public string FullName { get; internal set; }
    }
}
