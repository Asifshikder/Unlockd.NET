using System.Collections.Generic;
using System.Linq;
using Unlockd.Domain.Entities.SEOEntities;
using Unlockd.Repo;
using Unlockd.Service.Interface.SEOs;

namespace Unlockd.Service.Implementation.SEOs
{
   public class KeywordService : IKeywordService
    {
        private IRepository<Keyword> repository;

        public KeywordService(IRepository<Keyword> repository)
        {
            this.repository = repository;
        }

        public IEnumerable<Keyword> AllAsIEnumerable()
        {
            return repository.GetAllEnumerable();
        }
        
        public Keyword FirstOrDefault()
        {
            return repository.FirstOrDefault();
        }

        public IQueryable<Keyword> AllAsIQueryable()
        {
            return repository.GetAllQueryable();
        }

        public List<Keyword> AllAsList()
        {
            return repository.GetAll();
        }

        public void DeleteById(int id)
        {
            var entity = repository.Get(id);
            repository.Delete(entity);
        }

        public void DeleteEntity(Keyword keyword)
        {
            repository.Delete(keyword);
        }

        public Keyword GetById(int id)
        {
            return repository.Get(id);
        }

        public void InsertEntity(Keyword keyword)
        {
            repository.Insert(keyword);
        }

        public void UpdateEntity(Keyword keyword)
        {
            repository.Update(keyword);
        }
    }
}
