using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unlockd.Data;
using Unlockd.Domain;

namespace Unlockd.Repo
{
   public class Repository<T>: IRepository<T> where T: BaseEntity
    {
        private readonly UnlockdContext context;

        public Repository(UnlockdContext context)
        {
            this.context = context;
        }

        public void Delete(T entity)
        {
            context.Set<T>().Remove(entity);
            context.SaveChanges();
        }
        
        public void DeleteMultiple (T entity)
        {
            context.Set<T>().Remove(entity);
        }
        
        public void SaveChanges ()
        {
            context.SaveChanges();
        }

        public async Task DeleteAsync(T entity)
        {
            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync();
        }

        public T Get(long id)
        {
            return context.Set<T>().SingleOrDefault(s => s.Id == id);
        }
        
        public T FirstOrDefault()
        {
            return context.Set<T>().FirstOrDefault();
        }

        public List<T> GetAll()
        {
            return context.Set<T>().ToList();
        }

        public IEnumerable<T> GetAllEnumerable()
        {
            return context.Set<T>().AsEnumerable();
        }

        public IQueryable<T> GetAllQueryable()
        {
            return context.Set<T>().AsQueryable();
        }

        public async Task<T> GetAsync(long id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public void Insert(T entity)
        {
            context.Set<T>().Add(entity);
            context.SaveChanges();
        }

        public async Task InsertAsync(T entity)
        {
            context.Set<T>().Add(entity);
            await context.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            context.Set<T>().Update(entity);
            context.SaveChanges();
        }

        public async Task UpdateAsync(T entity)
        {
            context.Set<T>().Update(entity);
            await context.SaveChangesAsync();
        }
    }
}
