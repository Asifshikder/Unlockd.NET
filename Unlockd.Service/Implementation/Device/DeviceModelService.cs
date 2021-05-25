using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unlockd.Domain.Entities.Device;
using Unlockd.Repo;
using Unlockd.Service.Interface.Device;

namespace Unlockd.Service.Implementation.Device
{
   public class DeviceModelService: IDeviceModelService
    {
        private IRepository<DeviceModel> repository;

        public DeviceModelService(IRepository<DeviceModel> repository)
        {
            this.repository = repository;
        }

        public IEnumerable<DeviceModel> AllAsIEnumerable()
        {
            return repository.GetAllEnumerable();
        }

        public IQueryable<DeviceModel> AllAsIQueryable()
        {
            return repository.GetAllQueryable();
        }

        public List<DeviceModel> AllAsList()
        {
            return repository.GetAll();
        }

        public void DeleteById(int id)
        {
            var entity = repository.Get(id);
            repository.Delete(entity);
        }

        public void DeleteEntity(DeviceModel DeviceModel)
        {
            repository.Delete(DeviceModel);
        }

        public DeviceModel GetById(int id)
        {
            return repository.Get(id);
        }

        public void InsertEntity(DeviceModel DeviceModel)
        {
            repository.Insert(DeviceModel);
        }

        public void UpdateEntity(DeviceModel DeviceModel)
        {
            repository.Update(DeviceModel);
        }
    }
}
