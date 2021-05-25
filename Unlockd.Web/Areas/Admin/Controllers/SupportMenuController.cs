using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unlockd.Service.Interface.Services;
using Unlockd.Domain.Entities.Services;
using Microsoft.AspNetCore.Authorization;
using Unlockd.Web.Areas.Admin.Models.Services;
using Unlockd.Web.Helpers;

namespace Unlockd.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class SupportMenuController : Controller
    {
        private ISupportMenuService SupportMenuService;
        private IFileHandler fileHandler;

        public SupportMenuController(ISupportMenuService SupportMenuService, IFileHandler fileHandler)
        {
            this.SupportMenuService = SupportMenuService;
            this.fileHandler = fileHandler;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var entityList = SupportMenuService.AllAsIEnumerable();
            return View(entityList);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SupportMenuViewModel supportMenu)
        {
            if (supportMenu.MenuIconFile != null)
            {
                supportMenu.MenuIcon = fileHandler.UploadFile("SupportMenuItem", supportMenu.MenuIconFile);
            }
            SupportMenu menu = new SupportMenu();
            menu.MenuIcon = supportMenu.MenuIcon;
            menu.Name = supportMenu.Name;
            SupportMenuService.InsertEntity(menu);
            return Redirect("/Admin/SupportMenu/Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var country = SupportMenuService.GetById(id);

            SupportMenuViewModel viewModel = new SupportMenuViewModel()
            {
                Id = country.Id,
                Name = country.Name,
                MenuIcon = country.MenuIcon
            };

            return View(viewModel);
        }

        [HttpPost]
        [Route("/Admin/SupportMenu/Update")]
        [AutoValidateAntiforgeryToken]
        public IActionResult Update(SupportMenuViewModel viewModel)
        {
            if (viewModel.MenuIconFile != null)
            {
                viewModel.MenuIcon = fileHandler.UpdateFile(viewModel.MenuIcon, "SupportMenuItem", viewModel.MenuIconFile);
            }

            SupportMenu country = new SupportMenu()
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                MenuIcon = viewModel.MenuIcon

            };
            SupportMenuService.UpdateEntity(country);
            return Redirect("/Admin/SupportMenu/index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var country = SupportMenuService.GetById(id);
            return View(country);
        }

        [HttpPost]
        [Route("/Admin/SupportMenu/DeleteConfirm")]
        public IActionResult DeleteConfirm(SupportMenu country)
        {
            if (country.MenuIcon != null)
            {
                fileHandler.DeleteFile(country.MenuIcon);
            }
            SupportMenuService.DeleteEntity(country);
            return Redirect("/Admin/SupportMenu/Index");
        }
    }
}
