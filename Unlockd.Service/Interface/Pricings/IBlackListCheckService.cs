using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unlockd.Domain.Entities.Device;
using Unlockd.Domain.Entities.Pricings;

namespace Unlockd.Service.Interface
{
    public interface IBlackListCheckService
    {
        IEnumerable<BlackListCheck> AllAsIEnumerable();
        IQueryable<BlackListCheck> AllAsIQueryable();
        List<BlackListCheck> AllAsList();
        BlackListCheck FirstOrDefault();
        BlackListCheck GetById(int id);
        void InsertEntity(BlackListCheck BlackListCheck);
        void UpdateEntity(BlackListCheck BlackListCheck);
        void DeleteEntity(BlackListCheck BlackListCheck);
        void DeleteById(int id);
    }
}