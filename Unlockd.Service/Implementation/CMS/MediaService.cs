using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unlockd.Domain.Entities.CMS;
using Unlockd.Repo;
using Unlockd.Service.Interface.CMS;

namespace Unlockd.Service.Implementation.CMS
{
   public class MediaService: IMediaService
    {
        private IRepository<Media> repository;

        public MediaService(IRepository<Media> repository)
        {
            this.repository = repository;
        }

        public IEnumerable<Media> AllAsIEnumerable()
        {
            return repository.GetAllEnumerable();
        }

        public IQueryable<Media> AllAsIQueryable()
        {
            return repository.GetAllQueryable();
        }

        public List<Media> AllAsList()
        {
            return repository.GetAll();
        }

        public void DeleteById(long id)
        {
            var entity = repository.Get(id);
            repository.Delete(entity);
        }

        public void DeleteEntity(Media Media)
        {
            repository.Delete(Media);
        }

        public Media GetById(long id)
        {
            return repository.Get(id);
        }

        public void InsertEntity(Media Media)
        {
            repository.Insert(Media);
        }

        public void UpdateEntity(Media Media)
        {
            repository.Update(Media);
        }
    }
}
