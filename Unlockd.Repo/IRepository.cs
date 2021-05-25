using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unlockd.Domain;

namespace Unlockd.Repo
{
   public interface IRepository<T>where T: BaseEntity
    {
        IEnumerable<T> GetAllEnumerable();
        IQueryable<T> GetAllQueryable();
        List<T> GetAll();
        T Get(long id);
        T FirstOrDefault();
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void DeleteMultiple(T entity);
        void SaveChanges();
        Task<T> GetAsync(long id);
        Task InsertAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
