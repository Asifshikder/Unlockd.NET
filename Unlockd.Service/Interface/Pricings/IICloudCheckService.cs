using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unlockd.Domain.Entities.Device;
using Unlockd.Domain.Entities.Pricings;

namespace Unlockd.Service.Interface
{
    public interface IICloudCheckService
    {
        IEnumerable<ICloudCheck> AllAsIEnumerable();
        IQueryable<ICloudCheck> AllAsIQueryable();
        List<ICloudCheck> AllAsList();
        ICloudCheck FirstOrDefault();
        ICloudCheck GetById(int id);
        void InsertEntity(ICloudCheck ICloudCheck);
        void UpdateEntity(ICloudCheck ICloudCheck);
        void DeleteEntity(ICloudCheck ICloudCheck);
        void DeleteById(int id);
    }
}