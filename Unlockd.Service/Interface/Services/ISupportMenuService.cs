using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unlockd.Domain.Entities.Services;

namespace Unlockd.Service.Interface.Services
{
    public interface ISupportMenuService
    {
        IEnumerable<SupportMenu> AllAsIEnumerable();
        IQueryable<SupportMenu> AllAsIQueryable();
        List<SupportMenu> AllAsList();
        SupportMenu GetById(long id);
        void InsertEntity(SupportMenu SupportMenu);
        void UpdateEntity(SupportMenu SupportMenu);
        void DeleteEntity(SupportMenu SupportMenu);
        void DeleteWithBrandFAQ(SupportMenu SupportMenu);
        void DeleteById(long id);
    }
}