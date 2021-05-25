using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unlockd.Domain.Entities.Network;
using Unlockd.Repo;
using Unlockd.Service.Interface.Network;

namespace Unlockd.Service.Implementation.Network
{
   public class NetworkCarrierService: INetworkCarrierService
    {
        private IRepository<NetworkCarrier> repository;

        public NetworkCarrierService(IRepository<NetworkCarrier> repository)
        {
            this.repository = repository;
        }

        public IEnumerable<NetworkCarrier> AllAsIEnumerable()
        {
            return repository.GetAllEnumerable();
        }

        public IQueryable<NetworkCarrier> AllAsIQueryable()
        {
            return repository.GetAllQueryable();
        }

        public List<NetworkCarrier> AllAsList()
        {
            return repository.GetAll();
        }

        public void DeleteById(int id)
        {
            var entity = repository.Get(id);
            repository.Delete(entity);
        }

        public void DeleteEntity(NetworkCarrier NetworkCarrier)
        {
            repository.Delete(NetworkCarrier);
        }

        public NetworkCarrier GetById(int id)
        {
            return repository.Get(id);
        }

        public void InsertEntity(NetworkCarrier NetworkCarrier)
        {
            repository.Insert(NetworkCarrier);
        }

        public void UpdateEntity(NetworkCarrier NetworkCarrier)
        {
            repository.Update(NetworkCarrier);
        }
    }
}
