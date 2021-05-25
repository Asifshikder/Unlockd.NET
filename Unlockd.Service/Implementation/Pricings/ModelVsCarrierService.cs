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
   public class ModelVsCarrierService: IModelVsCarrierService
    {
        private IRepository<ModelVsCarrier> repository;

        public ModelVsCarrierService(IRepository<ModelVsCarrier> repository)
        {
            this.repository = repository;
        }

        public IEnumerable<ModelVsCarrier> AllAsIEnumerable()
        {
            return repository.GetAllEnumerable();
        }

        public IQueryable<ModelVsCarrier> AllAsIQueryable()
        {
            return repository.GetAllQueryable();
        }

        public List<ModelVsCarrier> AllAsList()
        {
            return repository.GetAll();
        }

        public ModelVsCarrier FirstOrDefault()
        {
            return repository.FirstOrDefault();
        }

        public void DeleteById(int id)
        {
            var entity = repository.Get(id);
            repository.Delete(entity);
        }

        public void DeleteEntity(ModelVsCarrier ModelVsCarrier)
        {
            repository.Delete(ModelVsCarrier);
        }

        public ModelVsCarrier GetById(int id)
        {
            return repository.Get(id);
        }

        public void InsertEntity(ModelVsCarrier ModelVsCarrier)
        {
            repository.Insert(ModelVsCarrier);
        }

        public void UpdateEntity(ModelVsCarrier ModelVsCarrier)
        {
            repository.Update(ModelVsCarrier);
        }
    }
}
