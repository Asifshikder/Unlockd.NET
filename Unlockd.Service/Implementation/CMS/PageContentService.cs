using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unlockd.Domain.Entities.CMS;
using Unlockd.Repo;
using Unlockd.Service.Interface.CMS;

namespace Unlockd.Service.Implementation.CMS
{
   public class PageContentService: IPageContentService
    {
        private IRepository<PageContent> repository;

        public PageContentService(IRepository<PageContent> repository)
        {
            this.repository = repository;
        }

        public IEnumerable<PageContent> AllAsIEnumerable()
        {
            return repository.GetAllEnumerable();
        }

        public IQueryable<PageContent> AllAsIQueryable()
        {
            return repository.GetAllQueryable();
        }

        public List<PageContent> AllAsList()
        {
            return repository.GetAll();
        }

        public void DeleteById(long id)
        {
            var entity = repository.Get(id);
            repository.Delete(entity);
        }

        public void DeleteEntity(PageContent PageContent)
        {
            repository.Delete(PageContent);
        }

        public PageContent GetById(long id)
        {
            return repository.Get(id);
        }

        public void InsertEntity(PageContent PageContent)
        {
            repository.Insert(PageContent);
        }

        public void UpdateEntity(PageContent PageContent)
        {
            repository.Update(PageContent);
        }
    }
}
