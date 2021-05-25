using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unlockd.Domain.Entities.Services;
using Unlockd.Repo;
using Unlockd.Service.Interface.Services;

namespace Unlockd.Service.Implementation.Services
{
   public class OurInfoService: IOurInfoService
    {
        private IRepository<OurInfo> repository;

        public OurInfoService(IRepository<OurInfo> repository)
        {
            this.repository = repository;
        }

        public IEnumerable<OurInfo> AllAsIEnumerable()
        {
            return repository.GetAllEnumerable();
        }

        public IQueryable<OurInfo> AllAsIQueryable()
        {
            return repository.GetAllQueryable();
        }

        public List<OurInfo> AllAsList()
        {
            return repository.GetAll();
        }

        public void DeleteById(long id)
        {
            var entity = repository.Get(id);
            repository.Delete(entity);
        }

        public void DeleteEntity(OurInfo OurInfo)
        {
            repository.Delete(OurInfo);
        }

        public OurInfo GetById(long id)
        {
            return repository.Get(id);
        }

        public void InsertEntity(OurInfo OurInfo)
        {
            repository.Insert(OurInfo);
        }

        public void UpdateEntity(OurInfo OurInfo)
        {
            repository.Update(OurInfo);
        }
    }
}
