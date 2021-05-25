using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unlockd.Domain.Entities.CMS;
using Unlockd.Service.Implementation.CMS;

namespace Unlockd.Service.Interface.CMS
{
    public interface IMediaService
    {
        IEnumerable<Media> AllAsIEnumerable();
        IQueryable<Media> AllAsIQueryable();
        List<Media> AllAsList();
        Media GetById(long id);
        void InsertEntity(Media media);
        void UpdateEntity(Media media);
        void DeleteEntity(Media media);
        void DeleteById(long id);
    }
}