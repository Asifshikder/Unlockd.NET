using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unlockd.Domain.Entities.Network;

namespace Unlockd.Service.Interface.Network
{
    public interface ICountryService
    {
        IEnumerable<Country> AllAsIEnumerable();
        IQueryable<Country> AllAsIQueryable();
        List<Country> AllAsList();
        Country GetById(int id);
        Country FirstOrDefault();
        void InsertEntity(Country country);
        void UpdateEntity(Country country);
        void DeleteEntity(Country country);
        void DeleteById(int id);
    }
}