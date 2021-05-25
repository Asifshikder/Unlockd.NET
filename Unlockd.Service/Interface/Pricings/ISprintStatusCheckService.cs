using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unlockd.Domain.Entities.Device;
using Unlockd.Domain.Entities.Pricings;

namespace Unlockd.Service.Interface
{
    public interface ISprintStatusCheckService
    {
        IEnumerable<SprintStatusCheck> AllAsIEnumerable();
        IQueryable<SprintStatusCheck> AllAsIQueryable();
        List<SprintStatusCheck> AllAsList();
        SprintStatusCheck FirstOrDefault();
        SprintStatusCheck GetById(int id);
        void InsertEntity(SprintStatusCheck SprintStatusCheck);
        void UpdateEntity(SprintStatusCheck SprintStatusCheck);
        void DeleteEntity(SprintStatusCheck SprintStatusCheck);
        void DeleteById(int id);
    }
}