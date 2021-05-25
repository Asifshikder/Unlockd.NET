using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unlockd.Domain.Entities.Auth;
using Unlockd.Repo;
using Unlockd.Service.Interface.Auth;

namespace Unlockd.Service.Implementation.Auth
{
    public class UserTypeService : IUserTypeService
    {
        private IRepository<UserType> repository;

        public UserTypeService(IRepository<UserType> repository)
        {
            this.repository = repository;
        }

        public IEnumerable<UserType> AllAsIEnumerable()
        {
            return repository.GetAllEnumerable();
        }

        public IQueryable<UserType> AllAsIQueryable()
        {
            return repository.GetAllQueryable();
        }

        public List<UserType> AllAsList()
        {
            return repository.GetAll();
        }

        public void DeleteById(long id)
        {
            var entity = repository.Get(id);
            repository.Delete(entity);
        }

        public void DeleteEntity(UserType userType)
        {
            repository.Delete(userType);
        }

        public UserType GetById(long id)
        {
            return repository.Get(id);
        }

        public void InsertEntity(UserType userType)
        {
            repository.Insert(userType);
        }

        public void UpdateEntity(UserType userType)
        {
            repository.Update(userType);
        }
    }
}
