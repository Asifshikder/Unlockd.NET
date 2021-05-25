using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unlockd.Domain.Entities.CMS;
using Unlockd.Service.Implementation.CMS;

namespace Unlockd.Service.Interface.CMS
{
    public interface IPageInfoService
    {
        IEnumerable<PageInfo> AllAsIEnumerable();
        IQueryable<PageInfo> AllAsIQueryable();
        List<PageInfo> AllAsList();
        PageInfo GetById(long id);
        void InsertEntity(PageInfo pageInfo);
        void UpdateEntity(PageInfo pageInfo);
        void DeleteEntity(PageInfo pageInfo);
        void DeleteById(long id);
    }
}