using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unlockd.Domain.Entities.Network;

namespace Unlockd.Service.Interface.Network
{
    public interface INetworkCarrierService
    {
        IEnumerable<NetworkCarrier> AllAsIEnumerable();
        IQueryable<NetworkCarrier> AllAsIQueryable();
        List<NetworkCarrier> AllAsList();
        NetworkCarrier GetById(int id);
        void InsertEntity(NetworkCarrier networkCarrier);
        void UpdateEntity(NetworkCarrier networkCarrier);
        void DeleteEntity(NetworkCarrier networkCarrier);
        void DeleteById(int id);
    }
}