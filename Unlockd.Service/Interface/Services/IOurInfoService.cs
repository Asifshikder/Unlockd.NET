using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unlockd.Domain.Entities.Services;

namespace Unlockd.Service.Interface.Services
{
    public interface IOurInfoService
    {
        IEnumerable<OurInfo> AllAsIEnumerable();
        IQueryable<OurInfo> AllAsIQueryable();
        List<OurInfo> AllAsList();
        OurInfo GetById(long id);
        void InsertEntity(OurInfo OurInfo);
        void UpdateEntity(OurInfo OurInfo);
        void DeleteEntity(OurInfo OurInfo);
        void DeleteById(long id);
    }
}