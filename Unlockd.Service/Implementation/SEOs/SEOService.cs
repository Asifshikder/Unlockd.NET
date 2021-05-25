using System.Collections.Generic;
using System.Linq;
using Unlockd.Domain.Entities.SEOEntities;
using Unlockd.Repo;
using Unlockd.Service.Interface.SEOs;

namespace Unlockd.Service.Implementation.SEOs
{
   public class SEOService : ISEOService
    {
        private IRepository<SEO> repository;

        public SEOService(IRepository<SEO> repository)
        {
            this.repository = repository;
        }

        public IEnumerable<SEO> AllAsIEnumerable()
        {
            return repository.GetAllEnumerable();
        }
        
        public SEO FirstOrDefault()
        {
            return repository.FirstOrDefault();
        }

        public IQueryable<SEO> AllAsIQueryable()
        {
            return repository.GetAllQueryable();
        }

        public List<SEO> AllAsList()
        {
            return repository.GetAll();
        }

        public void DeleteById(int id)
        {
            var entity = repository.Get(id);
            repository.Delete(entity);
        }

        public void DeleteEntity(SEO sEO)
        {
            repository.Delete(sEO);
        }

        public SEO GetById(int id)
        {
            return repository.Get(id);
        }

        public void InsertEntity(SEO sEO)
        {
            repository.Insert(sEO);
        }

        public void UpdateEntity(SEO sEO)
        {
            repository.Update(sEO);
        }
    }
}
