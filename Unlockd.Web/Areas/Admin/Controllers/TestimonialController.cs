using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Unlockd.Domain.Entities.Testimonials;
using Unlockd.Service.Interface.Testimonials;
using Unlockd.Web.Areas.Admin.Models.Testimonials;
using Unlockd.Web.Helpers;

namespace Unlockd.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class TestimonialController : Controller
    {
        private ITestimonialService testimonialService;
        private IFileHandler fileHandler;

        public TestimonialController(ITestimonialService testimonialService,
            IFileHandler fileHandler)
        {
            this.testimonialService = testimonialService;
            this.fileHandler = fileHandler;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var entityList = testimonialService.AllAsIEnumerable();
            return View(entityList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TestimonialViewModel viewModel)
        {
           

            Testimonial testimonial = new Testimonial()
            {
                Name = viewModel.Name,
                Title = viewModel.Title,
                Company = viewModel.Company,
                Message = viewModel.Message
            };

            testimonialService.InsertEntity(testimonial);
            return Redirect("/Admin/Testimonial/Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var testimonial = testimonialService.GetById(id);

            TestimonialViewModel viewModel = new TestimonialViewModel()
            {
                Id = testimonial.Id,
                Name = testimonial.Name,
                Title = testimonial.Title,
                Company = testimonial.Company,
                Message = testimonial.Message
            };

            return View(viewModel);
        }

        [HttpPost]
        [Route("/Admin/Testimonial/Update")]
        [AutoValidateAntiforgeryToken]
        public IActionResult Update(TestimonialViewModel viewModel)
        {
            Testimonial testimonial = new Testimonial()
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                Title = viewModel.Title,
                Company = viewModel.Company,
                Message = viewModel.Message

            };
            testimonialService.UpdateEntity(testimonial);
            return Redirect("/Admin/Testimonial/index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Testimonial testimonial = testimonialService.GetById(id);
            return View(testimonial);
        }

        [HttpPost]
        [Route("/Admin/Testimonial/DeleteConfirm")]
        [AutoValidateAntiforgeryToken]
        public IActionResult DeleteConfirm(Testimonial testimonial)
        {
            testimonialService.DeleteEntity(testimonial);
            return Redirect("/Admin/Testimonial/Index");
        }
    }
}