using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unlockd.Domain.Entities.Testimonials;

namespace Unlockd.Service.Interface.Testimonials
{
    public interface ITestimonialService
    {
        IEnumerable<Testimonial> AllAsIEnumerable();
        IQueryable<Testimonial> AllAsIQueryable();
        List<Testimonial> AllAsList();
        Testimonial GetById(long id);
        void InsertEntity(Testimonial fAQ);
        void UpdateEntity(Testimonial fAQ);
        void DeleteEntity(Testimonial fAQ);
        void DeleteById(long id);
    }
}