using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unlockd.Domain.Entities.Services;
using Unlockd.Repo;
using Unlockd.Service.Interface.Services;

namespace Unlockd.Service.Implementation.Services
{
   public class BrandFAQService: IBrandFAQService
    {
        private IRepository<BrandFAQ> repository;

        public BrandFAQService(IRepository<BrandFAQ> repository)
        {
            this.repository = repository;
        }

        public IEnumerable<BrandFAQ> AllAsIEnumerable()
        {
            return repository.GetAllEnumerable();
        }

        public IQueryable<BrandFAQ> AllAsIQueryable()
        {
            return repository.GetAllQueryable();
        }

        public List<BrandFAQ> AllAsList()
        {
            return repository.GetAll();
        }

        public void DeleteById(long id)
        {
            var entity = repository.Get(id);
            repository.Delete(entity);
        }

        public void DeleteEntity(BrandFAQ BrandFAQ)
        {
            repository.Delete(BrandFAQ);
        }

        public BrandFAQ GetById(long id)
        {
            return repository.Get(id);
        }

        public void InsertEntity(BrandFAQ BrandFAQ)
        {
            repository.Insert(BrandFAQ);
        }

        public void UpdateEntity(BrandFAQ BrandFAQ)
        {
            repository.Update(BrandFAQ);
        }
    }
}
