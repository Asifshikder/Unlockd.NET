using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unlockd.Domain.Entities.Services;
using Unlockd.Repo;
using Unlockd.Service.Interface.Services;

namespace Unlockd.Service.Implementation.Services
{
   public class ContactService: IContactService
    {
        private IRepository<Contact> repository;

        public ContactService(IRepository<Contact> repository)
        {
            this.repository = repository;
        }

        public IEnumerable<Contact> AllAsIEnumerable()
        {
            return repository.GetAllEnumerable();
        }

        public IQueryable<Contact> AllAsIQueryable()
        {
            return repository.GetAllQueryable();
        }

        public List<Contact> AllAsList()
        {
            return repository.GetAll();
        }

        public void DeleteById(long id)
        {
            var entity = repository.Get(id);
            repository.Delete(entity);
        }

        public void DeleteEntity(Contact Contact)
        {
            repository.Delete(Contact);
        }

        public Contact GetById(long id)
        {
            return repository.Get(id);
        }

        public void InsertEntity(Contact Contact)
        {
            repository.Insert(Contact);
        }

        public void UpdateEntity(Contact Contact)
        {
            repository.Update(Contact);
        }
    }
}
