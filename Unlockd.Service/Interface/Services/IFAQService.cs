using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unlockd.Domain.Entities.Services;

namespace Unlockd.Service.Interface.Services
{
    public interface IFAQService
    {
        IEnumerable<FAQ> AllAsIEnumerable();
        IQueryable<FAQ> AllAsIQueryable();
        List<FAQ> AllAsList();
        FAQ GetById(long id);
        void InsertEntity(FAQ fAQ);
        void UpdateEntity(FAQ fAQ);
        void DeleteEntity(FAQ fAQ);
        void DeleteById(long id);
    }
}