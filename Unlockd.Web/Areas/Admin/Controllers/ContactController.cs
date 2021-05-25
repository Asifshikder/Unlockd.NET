using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Unlockd.Domain.Entities.Services;
using Unlockd.Service.Interface.Network;
using Unlockd.Service.Interface.Services;

namespace Unlockd.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ContactController : Controller
    {
        private IContactService contactService;
        private ICountryService countryService;

        public ContactController(IContactService contactService,
            ICountryService countryService)
        {
            this.contactService = contactService;
            this.countryService = countryService;
        }


        [HttpGet]
        public IActionResult Index()
        {
            var entityList = contactService.AllAsIEnumerable();
             foreach(var item in entityList)
            {
                if(item.CountryId.HasValue)
                    item.Country = countryService.GetById(item.CountryId.Value);
            }
            return View(entityList);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Contact contact = contactService.GetById(id);
            return View(contact);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult DeleteConfirm(Contact contact)
        {
            contactService.DeleteEntity(contact);
            return Redirect("/Admin/contact/index");
        }
    }
}