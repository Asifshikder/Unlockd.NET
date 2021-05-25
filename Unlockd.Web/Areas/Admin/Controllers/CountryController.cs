using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Unlockd.Domain.Entities.Network;
using Unlockd.Service.Interface.Network;
using Unlockd.Web.Areas.Admin.Models.Network;
using Unlockd.Web.Helpers;

namespace Unlockd.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CountryController : Controller
    {
        private ICountryService countryService;
        private IFileHandler fileHandler;

        public CountryController(ICountryService countryService, IFileHandler fileHandler)
        {
            this.countryService = countryService;
            this.fileHandler = fileHandler;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var entityList = countryService.AllAsIEnumerable();
            return View(entityList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CountryViewModel viewModel)
        {
            if (viewModel.FlagIconFile != null)
            {
                viewModel.FlagIcon = fileHandler.ResizeAndUploadImage("Country", viewModel.FlagIconFile);
            }

            Country country = new Country()
            {
                Name = viewModel.Name,
                DisplayName = viewModel.DisplayName,
                FlagIcon = viewModel.FlagIcon,
                Currency = viewModel.Currency

            };

            countryService.InsertEntity(country);
            return Redirect("/Admin/Country/Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var country = countryService.GetById(id);

            CountryViewModel viewModel = new CountryViewModel()
            {
                Id = country.Id,
                Name = country.Name,
                DisplayName = country.DisplayName,
                FlagIcon = country.FlagIcon,
                Currency = country.Currency
            };

            return View(viewModel);
        }

        [HttpPost]
        [Route("/Admin/Country/Update")]
        [AutoValidateAntiforgeryToken]
        public IActionResult Update(CountryViewModel viewModel)
        {
            if (viewModel.FlagIconFile != null)
            {
                viewModel.FlagIcon = fileHandler.UpdateFile(viewModel.FlagIcon,"Country", viewModel.FlagIconFile);
            }

            Country country = new Country()
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                DisplayName = viewModel.DisplayName,
                FlagIcon = viewModel.FlagIcon,
                Currency = viewModel.Currency

            };
            countryService.UpdateEntity(country);
            return Redirect("/Admin/Country/index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var country = countryService.GetById(id);
            return View(country);
        }

        [HttpPost]
        [Route("/Admin/Country/DeleteConfirm")]
        public IActionResult DeleteConfirm(Country country)
        {
            if (country.FlagIcon != null)
            {
                fileHandler.DeleteFile(country.FlagIcon);
            }
            countryService.DeleteEntity(country);
            return Redirect("/Admin/Country/Index");
        }
    }
}