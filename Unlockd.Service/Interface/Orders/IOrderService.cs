using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unlockd.Domain.Entities.SalesAndOrder;

namespace Unlockd.Service.Interface.Orders
{
    public interface IOrderService
    {
        IEnumerable<Order> AllAsIEnumerable();
        IQueryable<Order> AllAsIQueryable();
        List<Order> AllAsList();
        Order GetById(int id);
        void InsertEntity(Order order);
        void UpdateEntity(Order order);
        void DeleteEntity(Order order);
        void DeleteById(int id);
    }
}