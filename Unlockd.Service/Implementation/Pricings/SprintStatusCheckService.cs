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
   public class SprintStatusCheckService: ISprintStatusCheckService
    {
        private IRepository<SprintStatusCheck> repository;

        public SprintStatusCheckService(IRepository<SprintStatusCheck> repository)
        {
            this.repository = repository;
        }

        public IEnumerable<SprintStatusCheck> AllAsIEnumerable()
        {
            return repository.GetAllEnumerable();
        }

        public IQueryable<SprintStatusCheck> AllAsIQueryable()
        {
            return repository.GetAllQueryable();
        }

        public List<SprintStatusCheck> AllAsList()
        {
            return repository.GetAll();
        }

        public SprintStatusCheck FirstOrDefault()
        {
            return repository.FirstOrDefault();
        }

        public void DeleteById(int id)
        {
            var entity = repository.Get(id);
            repository.Delete(entity);
        }

        public void DeleteEntity(SprintStatusCheck SprintStatusCheck)
        {
            repository.Delete(SprintStatusCheck);
        }

        public SprintStatusCheck GetById(int id)
        {
            return repository.Get(id);
        }

        public void InsertEntity(SprintStatusCheck SprintStatusCheck)
        {
            repository.Insert(SprintStatusCheck);
        }

        public void UpdateEntity(SprintStatusCheck SprintStatusCheck)
        {
            repository.Update(SprintStatusCheck);
        }
    }
}
