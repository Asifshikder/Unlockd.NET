using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Threading.Tasks;
using Unlockd.Domain.Entities.Network;
using Unlockd.Domain.Entities.Testimonials;
using Unlockd.Service.Interface.Network;
using Unlockd.Service.Interface.Testimonials;
using Unlockd.Web.Areas.Admin.Models.Network;
using Unlockd.Web.Models;

namespace Unlockd.Web.ViewComponents
{
    public class ReviewsViewComponent : ViewComponent
    {
        private ITestimonialService testimonialService;
        public ReviewsViewComponent(ITestimonialService testimonialService)
        {
            this.testimonialService = testimonialService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            //Reviews reviews1 = new Reviews();

            //var testimonials = testimonialService.AllAsIEnumerable().OrderByDescending(s => s.CreateDate);
            //List<Testimonial> model1 = new List<Testimonial>();
            //if (testimonials.Count() > 2)
            //{
            //    var testo1 = testimonials.Take(2);
            //    foreach (var item in testo1)
            //    {
            //        Testimonial reviews = new Testimonial();
            //        reviews = item;
            //        model1.Add(reviews);
            //    }
            //}
            //else
            //{
            //    model1 = null;
            //}

            //List<Testimonial> model2 = new List<Testimonial>();
            //if (testimonials.Count() > 4)
            //{
            //    var testo2 = testimonials.Skip(2).Take(2);
            //    foreach (var item in testo2)
            //    {
            //        Testimonial reviews = new Testimonial();
            //        reviews = item;
            //        model2.Add(reviews);
            //    }
            //}
            //else
            //{
            //    model2 = null;
            //}

            //List<Testimonial> model3 = new List<Testimonial>();
            //if (testimonials.Count() > 6)
            //{
            //    var testo3 = testimonials.Skip(4).Take(2);
            //    foreach (var item in testo3)
            //    {
            //        Testimonial reviews = new Testimonial();
            //        reviews = item;
            //        model3.Add(reviews);
            //    }
            //}
            //else
            //{
            //    model3 = null;
            //}

            //List<Testimonial> model4 = new List<Testimonial>();
            //if (testimonials.Count() > 7)
            //{
            //    var testo4 = testimonials.Skip(6).Take(2);
            //    foreach (var item in testo4)
            //    {
            //        Testimonial reviews = new Testimonial();
            //        reviews = item;
            //        model4.Add(reviews);
            //    }
            //}
            //else
            //{
            //    model4 = null;
            //}
            //reviews1.Testimonials.Add(model1);
            //reviews1.Add(model1);
            //reviews1.Add(model1);
            //reviews1.Add(model1);
            return View();
        }
    }
}
