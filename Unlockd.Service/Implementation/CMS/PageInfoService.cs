using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unlockd.Domain.Entities.CMS;
using Unlockd.Repo;
using Unlockd.Service.Interface.CMS;

namespace Unlockd.Service.Implementation.CMS
{
   public class PageInfoService: IPageInfoService
    {
        private IRepository<PageInfo> repository;

        public PageInfoService(IRepository<PageInfo> repository)
        {
            this.repository = repository;
        }

        public IEnumerable<PageInfo> AllAsIEnumerable()
        {
            return repository.GetAllEnumerable();
        }

        public IQueryable<PageInfo> AllAsIQueryable()
        {
            return repository.GetAllQueryable();
        }

        public List<PageInfo> AllAsList()
        {
            return repository.GetAll();
        }

        public void DeleteById(long id)
        {
            var entity = repository.Get(id);
            repository.Delete(entity);
        }

        public void DeleteEntity(PageInfo PageInfo)
        {
            repository.Delete(PageInfo);
        }

        public PageInfo GetById(long id)
        {
            return repository.Get(id);
        }

        public void InsertEntity(PageInfo PageInfo)
        {
            repository.Insert(PageInfo);
        }

        public void UpdateEntity(PageInfo PageInfo)
        {
            repository.Update(PageInfo);
        }
    }
}
