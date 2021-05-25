using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unlockd.Domain.Entities.Device;
using Unlockd.Domain.Entities.Pricings;
using Unlockd.Repo;
using Unlockd.Service.Interface;

namespace Unlockd.Service.Implementation.Device
{
   public class BlackListCheckService: IBlackListCheckService
    {
        private IRepository<BlackListCheck> repository;

        public BlackListCheckService(IRepository<BlackListCheck> repository)
        {
            this.repository = repository;
        }

        public IEnumerable<BlackListCheck> AllAsIEnumerable()
        {
            return repository.GetAllEnumerable();
        }

        public IQueryable<BlackListCheck> AllAsIQueryable()
        {
            return repository.GetAllQueryable();
        }

        public List<BlackListCheck> AllAsList()
        {
            return repository.GetAll();
        }

        public BlackListCheck FirstOrDefault()
        {
            return repository.FirstOrDefault();
        }

        public void DeleteById(int id)
        {
            var entity = repository.Get(id);
            repository.Delete(entity);
        }

        public void DeleteEntity(BlackListCheck BlackListCheck)
        {
            repository.Delete(BlackListCheck);
        }

        public BlackListCheck GetById(int id)
        {
            return repository.Get(id);
        }

        public void InsertEntity(BlackListCheck BlackListCheck)
        {
            repository.Insert(BlackListCheck);
        }

        public void UpdateEntity(BlackListCheck BlackListCheck)
        {
            repository.Update(BlackListCheck);
        }
    }
}
