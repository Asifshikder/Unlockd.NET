using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unlockd.Domain.Entities.Device;

namespace Unlockd.Service.Interface.Device
{
    public interface IDeviceModelService
    {
        IEnumerable<DeviceModel> AllAsIEnumerable();
        IQueryable<DeviceModel> AllAsIQueryable();
        List<DeviceModel> AllAsList();
        DeviceModel GetById(int id);
        void InsertEntity(DeviceModel deviceModel);
        void UpdateEntity(DeviceModel deviceModel);
        void DeleteEntity(DeviceModel deviceModel);
        void DeleteById(int id);
    }
}