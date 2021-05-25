using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unlockd.Domain.Entities.Auth;

namespace Unlockd.Service.Interface.Auth
{
   public interface IUserTypeService
    {
        IEnumerable<UserType> AllAsIEnumerable();
        IQueryable<UserType> AllAsIQueryable();
        List<UserType> AllAsList();
        UserType GetById(long id);
        void InsertEntity(UserType userType);
        void UpdateEntity(UserType userType);
        void DeleteEntity(UserType userType);
        void DeleteById(long id);
    }
}
