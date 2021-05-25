using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unlockd.Domain.Entities.Services;

namespace Unlockd.Service.Interface.Services
{
    public interface IBrandFAQService
    {
        IEnumerable<BrandFAQ> AllAsIEnumerable();
        IQueryable<BrandFAQ> AllAsIQueryable();
        List<BrandFAQ> AllAsList();
        BrandFAQ GetById(long id);
        void InsertEntity(BrandFAQ BrandFAQ);
        void UpdateEntity(BrandFAQ BrandFAQ);
        void DeleteEntity(BrandFAQ BrandFAQ);
        void DeleteById(long id);
    }
}