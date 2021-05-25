using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unlockd.Domain.Entities.Device;

namespace Unlockd.Service.Interface
{
    public interface IBrandService
    {
        IEnumerable<Brand> AllAsIEnumerable();
        IQueryable<Brand> AllAsIQueryable();
        List<Brand> AllAsList();
        Brand FirstOrDefault();
        Brand GetById(int id);
        void InsertEntity(Brand brand);
        void UpdateEntity(Brand brand);
        void DeleteEntity(Brand brand);
        void DeleteById(int id);
    }
}