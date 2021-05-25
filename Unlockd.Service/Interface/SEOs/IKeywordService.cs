using System.Collections.Generic;
using System.Linq;
using Unlockd.Domain.Entities.SEOEntities;

namespace Unlockd.Service.Interface.SEOs
{
    public interface IKeywordService
    {
        IEnumerable<Keyword> AllAsIEnumerable();
        IQueryable<Keyword> AllAsIQueryable();
        List<Keyword> AllAsList();
        Keyword GetById(int id);
        Keyword FirstOrDefault();
        void InsertEntity(Keyword keyword);
        void UpdateEntity(Keyword keyword);
        void DeleteEntity(Keyword keyword);
        void DeleteById(int id);
    }
}