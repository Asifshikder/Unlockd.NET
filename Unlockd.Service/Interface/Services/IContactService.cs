using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unlockd.Domain.Entities.Services;

namespace Unlockd.Service.Interface.Services
{
    public interface IContactService
    {
        IEnumerable<Contact> AllAsIEnumerable();
        IQueryable<Contact> AllAsIQueryable();
        List<Contact> AllAsList();
        Contact GetById(long id);
        void InsertEntity(Contact contact);
        void UpdateEntity(Contact contact);
        void DeleteEntity(Contact contact);
        void DeleteById(long id);
    }
}