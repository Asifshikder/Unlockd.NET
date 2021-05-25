using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unlockd.Domain.Entities.SalesAndOrder;
using Unlockd.Repo;
using Unlockd.Service.Interface.Orders;

namespace Unlockd.Service.Implementation.Orders
{
   public class OrderService : IOrderService
    {
        private IRepository<Order> repository;

        public OrderService(IRepository<Order> repository)
        {
            this.repository = repository;
        }

        public IEnumerable<Order> AllAsIEnumerable()
        {
            return repository.GetAllEnumerable();
        }

        public IQueryable<Order> AllAsIQueryable()
        {
            return repository.GetAllQueryable();
        }

        public List<Order> AllAsList()
        {
            return repository.GetAll();
        }

        public void DeleteById(int id)
        {
            var entity = repository.Get(id);
            repository.Delete(entity);
        }

        public void DeleteEntity(Order order)
        {
            repository.Delete(order);
        }

        public Order GetById(int id)
        {
            return repository.Get(id);
        }

        public void InsertEntity(Order order)
        {
            repository.Insert(order);
        }

        public void UpdateEntity(Order order)
        {
            repository.Update(order);
        }
    }
}
