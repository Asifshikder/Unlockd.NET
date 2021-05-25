using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Linq;
using Unlockd.Domain.Entities.SalesAndOrder;
using Unlockd.Service.Interface;
using Unlockd.Service.Interface.Device;
using Unlockd.Service.Interface.Network;
using Unlockd.Service.Interface.Orders;
using Unlockd.Web.Models;

namespace Unlockd.Web.Controllers
{
    public class OrderController : Controller
    {
        private ICountryService countryService;
        private INetworkCarrierService networkCarrierService;
        private IDeviceModelService deviceModelService;
        private IBrandService brandService;
        private IOrderService orderService;

        public OrderController(
            ICountryService countryService,
            INetworkCarrierService networkCarrierService,
            IDeviceModelService deviceModelService,
            IOrderService orderService,
            IBrandService brandService)
        {

            this.countryService = countryService;
            this.networkCarrierService = networkCarrierService;
            this.deviceModelService = deviceModelService;
            this.orderService = orderService;
            this.brandService = brandService;
        }
        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            return View(order);
        }

        [HttpPost]
        public IActionResult ProceedToCheckout(CartViewModel model)
        {
            ViewBag.countryList = new SelectList(countryService.AllAsIEnumerable().Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            OrderViewModel order = new OrderViewModel();
            if (model.radioService == null)
            {
                order.ServiceTypeId = 1;
                order.ServiceTypeName = "Standard Service";
            }
            else if (model.radioService == 1)
            {
                order.ServiceTypeId = 1; order.ServiceTypeName = "Standard Service";

            }
            else if (model.radioService == 2)
            {
                order.ServiceTypeId = 2; order.ServiceTypeName = "Premium Service";

            }
            else if (model.radioService == 3)
            {
                order.ServiceTypeId = 3; order.ServiceTypeName = "Pre-order Service";

            }
            else if (model.radioService == 4)
            {
                order.ServiceTypeId = 4; order.ServiceTypeName = "Checking Service";

            }
            else
            {
                order.ServiceTypeId = 1;
                order.ServiceTypeName = "Standard Service";
            }
            order.TotalPrice = model.TotalPrice;
            order.IMEI = model.IMEI;
            order.CountryId = model.CountryId;
            order.BrandId = model.BrandId;
            order.NetworkCarrierId = model.CarrierId;
            order.DeviceModelId = model.DeviceModelId;
            order.UnlockType = model.UnlockTypeId;
            order.NetworkCarrier = model.CarrierId != null || model.CarrierId != 0 ? networkCarrierService.GetById(model.CarrierId.Value) : null;
            order.Brand = model.BrandId != 0 ? brandService.GetById(model.BrandId) : null;
            order.DeviceModel = model.DeviceModelId != null || model.DeviceModelId != 0 ? deviceModelService.GetById(model.DeviceModelId.Value) : null;
            order.UnlockTypeName = model.UnlockTypeId == 1 ? "Carrier check" : model.UnlockTypeId == 2 ? "Blacklist check" : model.UnlockTypeId == 3 ? "Icloud activation check" : model.UnlockTypeId == 4 ? "Sprint status check" : model.UnlockTypeId == 5 ? "Phone unlock" : string.Empty;
            return View(order);
        }

        [HttpGet]
        public IActionResult OrderTracking()
        {
            OrderTraceViewModel model = new OrderTraceViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult OrderTracking(OrderTraceViewModel viewModel)
        {

            return RedirectToAction("OrderInfo", "Order", viewModel);
        }

        public IActionResult OrderInfo(OrderTraceViewModel viewModel)
        {
            OrderViewModel order = new OrderViewModel();
            var model = orderService.AllAsIEnumerable().Where(b => b.IMEI == viewModel.ImeiNo && b.Email.ToLower() == viewModel.EmailAddress.ToLower()).FirstOrDefault();
            if (model != null)
            {
                if (model.DeviceModelId != null)
                {
                    order.DeviceModelname = deviceModelService.GetById(order.DeviceModelId.Value).Name;
                }
                if (model.BrandId != 0)
                {
                    order.BrandName = brandService.GetById(order.BrandId.Value).Name;
                }
                if (model.NetworkCarrierId != null)
                {
                    order.NetworkCarrierName = networkCarrierService.GetById(order.NetworkCarrierId.Value).NetworkName;
                }
                if (model.CountryId != null)
                {
                    order.CountryId = model.CountryId;
                }
                order.Id = model.Id;
                if (model.CountryId != null)
                {
                    order.CountryId = model.CountryId;
                    order.CountryName = countryService.GetById(model.CountryId.Value).Name;
                }

                order.UnlockType = model.Id;
                order.UnlockTypeName = model.UnlockType == 1 ? "Carrier check" : model.UnlockType == 2 ? "Blacklist check" : model.UnlockType == 3 ? "Icloud activation check" : model.UnlockType == 4 ? "Sprint status check" : model.UnlockType == 5 ? "Phone unlock" : string.Empty;
                order.TotalPrice = model.TotalPrice;
                order.IMEI = model.IMEI;
                order.Email = model.Email;
                order.Forename = model.Forename;
                order.Surname = model.Surname;
                order.AddressLine = model.AddressLine;
                order.CityOrTown = model.CityOrTown;
                order.ZipOrPostcode = model.ZipOrPostcode;
                order.OrderTimeUTC = model.OrderTimeUTC;
                order.StatusName = model.OrderStatus == OrderStatus.Accepted ? "Accepted" : model.OrderStatus == OrderStatus.Cancel ? "Cancelled" : model.OrderStatus == OrderStatus.Completed ? "Completed" : model.OrderStatus == OrderStatus.Processing ? "Processing" : model.OrderStatus == OrderStatus.Pending ? "Pending" : model.OrderStatus == OrderStatus.Refunded ? "Refunded" : "";
                return View(order);
            }

            if (order == null)
                ViewBag.Msg = "You have currently no order to us with your given information!";

            return View(order);
        }

        public IActionResult CancelOrder(int id)
        {
            orderService.DeleteById(id);
            HttpContext.Session.Remove("OrderId");

            return RedirectToAction("Carrier", "Home");
        }

        public string FakeOrder()
        {
            Order order = new Order()
            {
                BrandId = 1,
                UnlockType = 1,
                TotalPrice = 28,
                IMEI = "357130085188500",
                Email = "test@test.com",
                Forename = "Kalam",
                Surname = "Kalam",
                AddressLine = "Shanir Akhra",
                CityOrTown = "Dhaka",
                ZipOrPostcode = "1230"
            };

            try
            {
                orderService.InsertEntity(order);

                return "done";
            }
            catch (Exception ex)
            {

                return "error";
            }
        }
    }
}
