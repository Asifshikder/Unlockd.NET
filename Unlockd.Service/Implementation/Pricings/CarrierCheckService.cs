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
   public class CarrierCheckService: ICarrierCheckService
    {
        private IRepository<CarrierCheck> repository;

        public CarrierCheckService(IRepository<CarrierCheck> repository)
        {
            this.repository = repository;
        }

        public IEnumerable<CarrierCheck> AllAsIEnumerable()
        {
            return repository.GetAllEnumerable();
        }

        public IQueryable<CarrierCheck> AllAsIQueryable()
        {
            return repository.GetAllQueryable();
        }

        public List<CarrierCheck> AllAsList()
        {
            return repository.GetAll();
        }

        public CarrierCheck FirstOrDefault()
        {
            return repository.FirstOrDefault();
        }

        public void DeleteById(int id)
        {
            var entity = repository.Get(id);
            repository.Delete(entity);
        }

        public void DeleteEntity(CarrierCheck CarrierCheck)
        {
            repository.Delete(CarrierCheck);
        }

        public CarrierCheck GetById(int id)
        {
            return repository.Get(id);
        }

        public void InsertEntity(CarrierCheck CarrierCheck)
        {
            repository.Insert(CarrierCheck);
        }

        public void UpdateEntity(CarrierCheck CarrierCheck)
        {
            repository.Update(CarrierCheck);
        }
    }
}
