using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using Unlockd.Domain.Entities.SalesAndOrder;
using Unlockd.Service.Interface;
using Unlockd.Service.Interface.Device;
using Unlockd.Service.Interface.Network;
using Unlockd.Service.Interface.Orders;
using Unlockd.Web.Areas.Admin.Models.Orders;

namespace Unlockd.Wes.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ManageOrderController : Controller
    {
        private IOrderService orderService;
        private IDeviceModelService deviceModelService;
        private INetworkCarrierService networkCarrierService;
        private ICountryService countryService;
        private IBrandService brandService;

        public ManageOrderController(IOrderService orderService,
            IDeviceModelService deviceModelService,
            INetworkCarrierService networkCarrierService,
            ICountryService countryService, IBrandService brandService)
        {
            this.orderService = orderService;
            this.deviceModelService = deviceModelService;
            this.networkCarrierService = networkCarrierService;
            this.countryService = countryService;
            this.brandService = brandService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.brandlist = new SelectList(brandService.AllAsIEnumerable().Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            ViewBag.countrylist = new SelectList(countryService.AllAsIEnumerable().Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            ViewBag.unlockTypeList = new SelectList(unlockTypes.Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");
            ViewBag.statusList = new SelectList(statuses.Select(s => new { Id = s.Id, Name = s.Name }), "Id", "Name");

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GetAll()
        {
            JsonResult result;
            try
            {
                int countryddl = 0;
                int unlocktypeddl = 0;
                int brandddl = 0;
                var brandid = HttpContext.Request.Form["brandId"];
                var countryid = HttpContext.Request.Form["countryId"];
                var unlocktypeid = HttpContext.Request.Form["unlockTypeId"];
                if (!string.IsNullOrEmpty(brandid))
                {
                    brandddl = int.Parse(brandid);
                }
                if (!string.IsNullOrEmpty(countryid))
                {
                    countryddl = int.Parse(countryid);
                }
                if (!string.IsNullOrEmpty(unlocktypeid))
                {
                    unlocktypeddl = int.Parse(unlocktypeid);
                }
                string search = HttpContext.Request.Form["search[value]"][0];
                string draw = HttpContext.Request.Form["draw"][0];
                string order = HttpContext.Request.Form["order[0][column]"][0];
                string orderDir = HttpContext.Request.Form["order[0][dir]"][0];
                int startRec = Convert.ToInt32(HttpContext.Request.Form["start"][0]);
                int pageSize = Convert.ToInt32(HttpContext.Request.Form["length"][0]);
                int totalRecords = 0;
                var firstPartOfQuery = orderService.AllAsIEnumerable().OrderByDescending(s => s.CreateDate).AsQueryable();
                int ifSearch = 0;
                var secondPartOfQuery = (brandddl != 0 && countryddl != 0 && unlocktypeddl != 0) ? firstPartOfQuery.Where(s => s.BrandId == brandddl && s.CountryId == countryddl && s.UnlockType == unlocktypeddl).ToList()
                      : (brandddl != 0 && countryddl != 0 && unlocktypeddl == 0) ? firstPartOfQuery.Where(s => s.BrandId == brandddl && s.CountryId == countryddl).ToList()
                      : (brandddl != 0 && countryddl == 0 && unlocktypeddl != 0) ? firstPartOfQuery.Where(s => s.BrandId == brandddl && s.CountryId == countryddl).ToList()
                      : (brandddl != 0 && countryddl == 0 && unlocktypeddl == 0) ? firstPartOfQuery.Where(s => s.BrandId == brandddl).ToList()
                      : (brandddl == 0 && countryddl == 0 && unlocktypeddl != 0) ? firstPartOfQuery.Where(s => s.UnlockType == unlocktypeddl).ToList()
                      : (brandddl == 0 && countryddl != 0 && unlocktypeddl == 0) ? firstPartOfQuery.Where(s => s.CountryId == countryddl).ToList()
                      : (brandddl == 0 && countryddl != 0 && unlocktypeddl != 0) ? firstPartOfQuery.Where(s => s.CountryId == countryddl && s.UnlockType == unlocktypeddl).ToList()
                      : firstPartOfQuery.ToList();
               
                List<OrderListViewModel> data = new List<OrderListViewModel>();

                if (secondPartOfQuery.Count() > 0)
                {
                    totalRecords = secondPartOfQuery.AsEnumerable().Count();
                    data = secondPartOfQuery.AsEnumerable().Skip(startRec).Take(pageSize).Select(

                            s => new OrderListViewModel
                            {
                                Id = s.Id,
                                DeviceModelName =s.DeviceModelId!=null? deviceModelService.GetById(s.DeviceModelId.Value).Name:"",
                                BrandName = s.BrandId!=0?brandService.GetById(s.BrandId).Name:"",
                                NetworkCarrierName =s.NetworkCarrierId!=null? networkCarrierService.GetById(s.NetworkCarrierId.Value).NetworkName:"",
                                CountryName =s.CountryId!=0? countryService.GetById(networkCarrierService.GetById(s.NetworkCarrierId.Value).CountryId).Name:"",
                                UnlockTypeName = s.UnlockType == 1 ? "Carrier check" : s.UnlockType == 2 ? "Blacklist check" : s.UnlockType == 3 ? "Icloud activation check" : s.UnlockType == 4 ? "Sprint status check" : s.UnlockType == 5 ? "Phone unlock" : string.Empty,
                                TotalPrice = s.TotalPrice,
                                IMEI = s.IMEI,
                                Email = s.Email,
                                Forename = s.Forename,
                                Surname = s.Surname,
                                FullName =s.Forename+" "+s.Surname,
                                OrderStatusName = s.OrderStatus == OrderStatus.Pending ? "Pending" : s.OrderStatus == OrderStatus.Accepted ? "Accepted" : s.OrderStatus == OrderStatus.Processing ? "Processing" : s.OrderStatus == OrderStatus.Completed ? "Completed" : s.OrderStatus == OrderStatus.Refunded ? "Refunded" : s.OrderStatus == OrderStatus.Cancel ? "Cancelled" : "Unknwon"
                            })
                        .OrderByDescending(s => s.Id).ToList();
                }

                data = this.SortByColumnWithOrderforEmployee(order, orderDir, data);
                int recFilter = (!string.IsNullOrEmpty(search) && !string.IsNullOrWhiteSpace(search)) ? ifSearch : firstPartOfQuery.AsEnumerable().Count();

                result = this.Json(new
                {
                    draw = Convert.ToInt32(draw),
                    recordsTotal = totalRecords,
                    recordsFiltered = recFilter,
                    data = data
                });

                return result;
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                return Json(new
                {
                    draw = 0,
                    recordsTotal = 0,
                    recordsFiltered = 0,
                    data = new List<OrderListViewModel>()
                });
            }
        }

        private List<OrderListViewModel> SortByColumnWithOrderforEmployee(string order, string orderDir, List<OrderListViewModel> data)
        {
            List<OrderListViewModel> lst = new List<OrderListViewModel>();
            try
            {
                switch (order)
                {

                    case "0":
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.Id).ToList() : data.OrderBy(p => p.Id).ToList();
                        break;
                    case "1":
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.BrandName).ToList() : data.OrderBy(p => p.BrandName).ToList();
                        break;
                    case "2":
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.Email).ToList() : data.OrderBy(p => p.Email).ToList();
                        break;
                    case "3":
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.CountryName).ToList() : data.OrderBy(p => p.CountryName).ToList();
                        break;

                    default:
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.Id).ToList() : data.OrderByDescending(p => p.Id).ToList();
                        break;
                }
            }
            catch (Exception ex)
            {

                Console.Write(ex);
            }
            return lst;
        }

        public IActionResult Details(int id)
        {
            var order = orderService.GetById(id);
            OrderViewModel viewModel = new OrderViewModel()
            {
                Id = order.Id,
                CreateDate = order.CreateDate,
                DeviceModelName = deviceModelService.GetById(order.DeviceModelId.Value).Name,
                BrandName =order.BrandId!=0? deviceModelService.GetById(order.BrandId).Name:"",
                NetworkCarrierName = networkCarrierService.GetById(order.NetworkCarrierId.Value).NetworkName,
                CountryName = countryService.GetById(networkCarrierService.GetById(order.NetworkCarrierId.Value).CountryId).Name,
                UnlockTypeName = order.UnlockType == 1 ? "Carrier check" : order.UnlockType == 2 ? "Blacklist check" : order.UnlockType == 3 ? "Icloud activation check" : order.UnlockType == 4 ? "Sprint status check" : order.UnlockType == 5 ? "Phone unlock" : string.Empty,
                UnlockType =order.UnlockType,
                TotalPrice = order.TotalPrice,
                IMEI = order.IMEI,
                Email = order.Email,
                Forename = order.Forename,
                Surname = order.Surname,
                AddressLine = order.AddressLine,
                CityOrTown = order.CityOrTown,
                ZipOrPostcode = order.ZipOrPostcode,
                OrderStatus = order.OrderStatus
            };

            return View(viewModel);
        }

        public IActionResult ChangeOrderStatus(int id, OrderStatus status, string returnUrl)
        {
            var order = orderService.GetById(id);

            order.OrderStatus = status;

            orderService.UpdateEntity(order);

            return LocalRedirect(returnUrl ?? Url.Action(nameof(Index)));
        }

        public IActionResult Delete(int id)
        {
            var order = orderService.GetById(id);

            return View(order);
        }

        [HttpPost]
        public IActionResult DeleteConfirm(int id)
        {
            orderService.DeleteById(id);

            return RedirectToAction(nameof(Index));
        }
        List<UnlockType> unlockTypes = new List<UnlockType>() {
        new UnlockType(){ Id=1,Name ="Carrier check" },
        new UnlockType(){ Id=2,Name ="Blacklist check" },
        new UnlockType(){ Id=3,Name ="ICloud activation check" },
        new UnlockType(){ Id=4,Name ="Sprint Status check" },
        new UnlockType(){ Id=5,Name ="Phone Unlock" }
        };
        List<OrderStatuses> statuses = new List<OrderStatuses>() {
        new OrderStatuses(){ Id=1,Name ="Pending" },
        new OrderStatuses(){ Id=2,Name ="Accepted" },
        new OrderStatuses(){ Id=3,Name ="Processing" },
        new OrderStatuses(){ Id=4,Name ="Completed" },
        new OrderStatuses(){ Id=5,Name ="Refunded" },
        new OrderStatuses(){ Id=6,Name ="Cancelled" },
        };
    }
    public class UnlockType
    {
        public int Id { get; set; }
        public string Name { get; set; }


    }
    public class OrderStatuses
    {
        public int Id { get; set; }
        public string Name { get; set; }


    }
}
