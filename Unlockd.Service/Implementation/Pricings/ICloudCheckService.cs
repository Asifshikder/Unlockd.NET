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
   public class ICloudCheckService: IICloudCheckService
    {
        private IRepository<ICloudCheck> repository;

        public ICloudCheckService(IRepository<ICloudCheck> repository)
        {
            this.repository = repository;
        }

        public IEnumerable<ICloudCheck> AllAsIEnumerable()
        {
            return repository.GetAllEnumerable();
        }

        public IQueryable<ICloudCheck> AllAsIQueryable()
        {
            return repository.GetAllQueryable();
        }

        public List<ICloudCheck> AllAsList()
        {
            return repository.GetAll();
        }

        public ICloudCheck FirstOrDefault()
        {
            return repository.FirstOrDefault();
        }

        public void DeleteById(int id)
        {
            var entity = repository.Get(id);
            repository.Delete(entity);
        }

        public void DeleteEntity(ICloudCheck ICloudCheck)
        {
            repository.Delete(ICloudCheck);
        }

        public ICloudCheck GetById(int id)
        {
            return repository.Get(id);
        }

        public void InsertEntity(ICloudCheck ICloudCheck)
        {
            repository.Insert(ICloudCheck);
        }

        public void UpdateEntity(ICloudCheck ICloudCheck)
        {
            repository.Update(ICloudCheck);
        }
    }
}
