using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unlockd.Domain.Entities.Device;
using Unlockd.Domain.Entities.Pricings;

namespace Unlockd.Service.Interface
{
    public interface ICarrierCheckService
    {
        IEnumerable<CarrierCheck> AllAsIEnumerable();
        IQueryable<CarrierCheck> AllAsIQueryable();
        List<CarrierCheck> AllAsList();
        CarrierCheck FirstOrDefault();
        CarrierCheck GetById(int id);
        void InsertEntity(CarrierCheck CarrierCheck);
        void UpdateEntity(CarrierCheck CarrierCheck);
        void DeleteEntity(CarrierCheck CarrierCheck);
        void DeleteById(int id);
    }
}