using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unlockd.Domain.Entities.Network;
using Unlockd.Service.Interface.Network;
using Unlockd.Web.Areas.Admin.Models.Network;
using Unlockd.Web.Helpers;

namespace Unlockd.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class NetworkCarrierController : Controller
    {
        private ICountryService _countryService;
        private INetworkCarrierService _networkCarrierService;
        private IFileHandler _fileHandler;

        public NetworkCarrierController(ICountryService countryService,
            INetworkCarrierService networkCarrierService,
            IFileHandler fileHandler)
        {
            _countryService = countryService;
            _networkCarrierService = networkCarrierService;
            _fileHandler = fileHandler;
    }

        // GET: NetworkCarrierController
        public IActionResult Index()
        {
            var countries = _countryService.AllAsList().OrderBy(b => b.Id);
            return View(countries);
        }
        
        public IActionResult CarrierList(int id)
        {
            var carriers = _networkCarrierService.AllAsList().Where(b => b.CountryId == id);
            var country = _countryService.GetById(id);
            foreach (var item in carriers)
            {
                item.Country = country;
            }

            ViewBag.CountryId = id;
            return View(carriers);
        }

        // GET: NetworkCarrierController/Create
        public ActionResult Create(int id)
        {
            ViewBag.CountryId = id;
            return View();
        }

        // POST: NetworkCarrierController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(int id, NetworkCarrierViewModel viewModel)
        {
            if (viewModel.CarrierIconFile != null)
            {
                viewModel.CarrierIcon = _fileHandler.UploadFile("Carrier", viewModel.CarrierIconFile);
            }
            if (viewModel.CovorPhotoFile != null)
            {
                viewModel.CovorPhoto = _fileHandler.UploadFile("Carrier", viewModel.CovorPhotoFile);
            }

            NetworkCarrier carrier = new NetworkCarrier()
            {
                NetworkName = viewModel.NetworkName,
                CarrierIcon = viewModel.CarrierIcon,
                BasePrice = viewModel.BasePrice,
                CovorPhoto = viewModel.CovorPhoto,
                Description = viewModel.Description,
                CountryId = id
            };

            _networkCarrierService.InsertEntity(carrier);
            return RedirectToAction("CarrierList", new {id});
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var networkCarrier = _networkCarrierService.GetById(id);

            NetworkCarrierViewModel viewModel = new NetworkCarrierViewModel()
            {
                Id = networkCarrier.Id,
                NetworkName = networkCarrier.NetworkName,
                CarrierIcon = networkCarrier.CarrierIcon,
                CovorPhoto = networkCarrier.CovorPhoto,
                Description = networkCarrier.Description,
                BasePrice = networkCarrier.BasePrice.Value,
                CountryId = networkCarrier.CountryId,
            };

            return View(viewModel);
        }


        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Update(NetworkCarrierViewModel viewModel)
        {
            if (viewModel.CarrierIconFile != null)
            {
                viewModel.CarrierIcon = _fileHandler.UpdateFile(viewModel.CarrierIcon,"Carrier", viewModel.CarrierIconFile);
            }
            if (viewModel.CovorPhotoFile != null)
            {
                viewModel.CovorPhoto = _fileHandler.UpdateFile(viewModel.CovorPhoto,"Carrier", viewModel.CovorPhotoFile);
            }

            NetworkCarrier country = new NetworkCarrier()
            {
                Id = viewModel.Id,
                NetworkName = viewModel.NetworkName,
                CountryId = viewModel.CountryId,
                BasePrice = viewModel.BasePrice,
                CovorPhoto = viewModel.CovorPhoto,
                Description = viewModel.Description,
                CarrierIcon = viewModel.CarrierIcon

            };
            _networkCarrierService.UpdateEntity(country);
            return RedirectToAction("CarrierList", new { id = viewModel.CountryId });
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var networkCarrier = _networkCarrierService.GetById(id);
            return View(networkCarrier);
        }

        [HttpPost]
        public IActionResult DeleteConfirm(NetworkCarrier networkCarrier)
        {
            int returnKey = networkCarrier.CountryId;
            if (networkCarrier.CarrierIcon != null)
            {
                _fileHandler.DeleteFile(networkCarrier.CarrierIcon);
            }
            _networkCarrierService.DeleteEntity(networkCarrier);
            return RedirectToAction("CarrierList", new { id = returnKey });
        }
    }
}
