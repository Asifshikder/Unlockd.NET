using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unlockd.Domain.Entities.Services;
using Unlockd.Repo;
using Unlockd.Service.Interface.Services;

namespace Unlockd.Service.Implementation.Services
{
   public class SupportMenuService: ISupportMenuService
    {
        private IRepository<SupportMenu> repository;
        private IRepository<BrandFAQ> brandrepository;

        public SupportMenuService(IRepository<SupportMenu> repository, IRepository<BrandFAQ> brandrepository)
        {
            this.repository = repository;
            this.brandrepository = brandrepository;
        }

        public IEnumerable<SupportMenu> AllAsIEnumerable()
        {
            return repository.GetAllEnumerable();
        }

        public IQueryable<SupportMenu> AllAsIQueryable()
        {
            return repository.GetAllQueryable();
        }

        public List<SupportMenu> AllAsList()
        {
            return repository.GetAll();
        }

        public void DeleteById(long id)
        {
            var entity = repository.Get(id);
            repository.Delete(entity);
        }

        public void DeleteEntity(SupportMenu SupportMenu)
        {
            repository.Delete(SupportMenu);
        }

        public void DeleteWithBrandFAQ(SupportMenu SupportMenu)
        {
            var getllbrandFAQ = brandrepository.GetAll().Where(s => s.SupportMenuId == SupportMenu.Id).ToList();
            foreach(var item in getllbrandFAQ)
            {
                brandrepository.DeleteMultiple(item);
            }
            repository.Delete(SupportMenu);
        }

        public SupportMenu GetById(long id)
        {
            return repository.Get(id);
        }

        public void InsertEntity(SupportMenu SupportMenu)
        {
            repository.Insert(SupportMenu);
        }

        public void UpdateEntity(SupportMenu SupportMenu)
        {
            repository.Update(SupportMenu);
        }
    }
}
