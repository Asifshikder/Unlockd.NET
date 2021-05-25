using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unlockd.Domain.Entities.Network;
using Unlockd.Repo;
using Unlockd.Service.Interface.Network;

namespace Unlockd.Service.Implementation.Network
{
   public class CountryService: ICountryService
    {
        private IRepository<Country> repository;

        public CountryService(IRepository<Country> repository)
        {
            this.repository = repository;
        }

        public IEnumerable<Country> AllAsIEnumerable()
        {
            return repository.GetAllEnumerable();
        }
        
        public Country FirstOrDefault()
        {
            return repository.FirstOrDefault();
        }

        public IQueryable<Country> AllAsIQueryable()
        {
            return repository.GetAllQueryable();
        }

        public List<Country> AllAsList()
        {
            return repository.GetAll();
        }

        public void DeleteById(int id)
        {
            var entity = repository.Get(id);
            repository.Delete(entity);
        }

        public void DeleteEntity(Country Country)
        {
            repository.Delete(Country);
        }

        public Country GetById(int id)
        {
            return repository.Get(id);
        }

        public void InsertEntity(Country Country)
        {
            repository.Insert(Country);
        }

        public void UpdateEntity(Country Country)
        {
            repository.Update(Country);
        }
    }
}
