using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UmbrellaShop.Core.DomainService;
using UmbrellaShop.Core.Entity;

namespace UmbrellaShop.Core.ApplicationService.ServiceImplemetation
{
    public class OrderService : IOrderService
    {
        IOrderRepository repo;
        public OrderService(IOrderRepository repo){
            this.repo = repo;
        }
        public Order CreateOrder(Order Order)
        {
            return repo.Create(Order);
        }

        public Order DeleteOrder(int id)
        {
            return repo.Delete(id);
        }

        public List<Order> GetOrder()
        {
            return repo.ReadOrders().ToList();
        }

        public Order getOrderByID(int id)
        {
            return repo.ReadByID(id);
        }

        public Order NewOrder(int id, DateTime OrderPlaced, DateTime OrderShipped, string BillingAddress, Customer customer)
        {
            return new Order {Id = id, BillingAddress = BillingAddress, OrderPlaced = OrderPlaced, OrderShipped = OrderShipped, Customer = customer };
        }

        public Order UpdateOrder(int id, Order Order)
        {
            if (this.DeleteOrder(id) != null) {
                Order.Id = id;
                 return CreateOrder(Order);
            }
            return null;
        }
    }
}
