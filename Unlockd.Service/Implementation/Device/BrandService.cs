using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unlockd.Domain.Entities.Device;
using Unlockd.Repo;
using Unlockd.Service.Interface;

namespace Unlockd.Service.Implementation.Device
{
   public class BrandService: IBrandService
    {
        private IRepository<Brand> repository;

        public BrandService(IRepository<Brand> repository)
        {
            this.repository = repository;
        }

        public IEnumerable<Brand> AllAsIEnumerable()
        {
            return repository.GetAllEnumerable();
        }

        public IQueryable<Brand> AllAsIQueryable()
        {
            return repository.GetAllQueryable();
        }

        public List<Brand> AllAsList()
        {
            return repository.GetAll();
        }

        public Brand FirstOrDefault()
        {
            return repository.FirstOrDefault();
        }

        public void DeleteById(int id)
        {
            var entity = repository.Get(id);
            repository.Delete(entity);
        }

        public void DeleteEntity(Brand Brand)
        {
            repository.Delete(Brand);
        }

        public Brand GetById(int id)
        {
            return repository.Get(id);
        }

        public void InsertEntity(Brand Brand)
        {
            repository.Insert(Brand);
        }

        public void UpdateEntity(Brand Brand)
        {
            repository.Update(Brand);
        }
    }
}
