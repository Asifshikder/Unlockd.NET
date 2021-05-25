using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unlockd.Domain.Entities.CMS;

namespace Unlockd.Service.Interface.CMS
{
    public interface IPageContentService
    {
        IEnumerable<PageContent> AllAsIEnumerable();
        IQueryable<PageContent> AllAsIQueryable();
        List<PageContent> AllAsList();
        PageContent GetById(long id);
        void InsertEntity(PageContent PageContent);
        void UpdateEntity(PageContent PageContent);
        void DeleteEntity(PageContent PageContent);
        void DeleteById(long id);
    }
}