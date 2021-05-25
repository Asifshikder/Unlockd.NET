using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unlockd.Domain.Entities.Device;
using Unlockd.Domain.Entities.Pricings;

namespace Unlockd.Service.Interface
{
    public interface IModelVsCarrierService
    {
        IEnumerable<ModelVsCarrier> AllAsIEnumerable();
        IQueryable<ModelVsCarrier> AllAsIQueryable();
        List<ModelVsCarrier> AllAsList();
        ModelVsCarrier FirstOrDefault();
        ModelVsCarrier GetById(int id);
        void InsertEntity(ModelVsCarrier ModelVsCarrier);
        void UpdateEntity(ModelVsCarrier ModelVsCarrier);
        void DeleteEntity(ModelVsCarrier ModelVsCarrier);
        void DeleteById(int id);
    }
}