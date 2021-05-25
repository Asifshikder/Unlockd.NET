using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unlockd.Domain.Entities.Services;
using Unlockd.Repo;
using Unlockd.Service.Interface.Services;

namespace Unlockd.Service.Implementation.Services
{
   public class FAQService: IFAQService
    {
        private IRepository<FAQ> repository;

        public FAQService(IRepository<FAQ> repository)
        {
            this.repository = repository;
        }

        public IEnumerable<FAQ> AllAsIEnumerable()
        {
            return repository.GetAllEnumerable();
        }

        public IQueryable<FAQ> AllAsIQueryable()
        {
            return repository.GetAllQueryable();
        }

        public List<FAQ> AllAsList()
        {
            return repository.GetAll();
        }

        public void DeleteById(long id)
        {
            var entity = repository.Get(id);
            repository.Delete(entity);
        }

        public void DeleteEntity(FAQ FAQ)
        {
            repository.Delete(FAQ);
        }

        public FAQ GetById(long id)
        {
            return repository.Get(id);
        }

        public void InsertEntity(FAQ FAQ)
        {
            repository.Insert(FAQ);
        }

        public void UpdateEntity(FAQ FAQ)
        {
            repository.Update(FAQ);
        }
    }
}
