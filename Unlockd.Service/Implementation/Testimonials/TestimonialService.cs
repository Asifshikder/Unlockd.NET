using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unlockd.Domain.Entities.Testimonials;
using Unlockd.Repo;
using Unlockd.Service.Interface.Testimonials;

namespace Unlockd.Service.Implementation.Testimonials
{
   public class TestimonialService : ITestimonialService
    {
        private IRepository<Testimonial> repository;

        public TestimonialService(IRepository<Testimonial> repository)
        {
            this.repository = repository;
        }

        public IEnumerable<Testimonial> AllAsIEnumerable()
        {
            return repository.GetAllEnumerable();
        }

        public IQueryable<Testimonial> AllAsIQueryable()
        {
            return repository.GetAllQueryable();
        }

        public List<Testimonial> AllAsList()
        {
            return repository.GetAll();
        }

        public void DeleteById(long id)
        {
            var entity = repository.Get(id);
            repository.Delete(entity);
        }

        public void DeleteEntity(Testimonial Testimonial)
        {
            repository.Delete(Testimonial);
        }

        public Testimonial GetById(long id)
        {
            return repository.Get(id);
        }

        public void InsertEntity(Testimonial Testimonial)
        {
            repository.Insert(Testimonial);
        }

        public void UpdateEntity(Testimonial Testimonial)
        {
            repository.Update(Testimonial);
        }
    }
}
