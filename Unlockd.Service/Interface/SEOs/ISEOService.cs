using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unlockd.Domain.Entities.Network;
using Unlockd.Domain.Entities.SEOEntities;

namespace Unlockd.Service.Interface.SEOs
{
    public interface ISEOService
    {
        IEnumerable<SEO> AllAsIEnumerable();
        IQueryable<SEO> AllAsIQueryable();
        List<SEO> AllAsList();
        SEO GetById(int id);
        SEO FirstOrDefault();
        void InsertEntity(SEO sEO);
        void UpdateEntity(SEO sEO);
        void DeleteEntity(SEO sEO);
        void DeleteById(int id);
    }
}