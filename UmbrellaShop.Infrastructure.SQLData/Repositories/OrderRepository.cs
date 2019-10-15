using UmbrellaShop.Core.DomainService;
using UmbrellaShop.Core.Entity;
using UmbrellaShop.Infrastructure.SQLData;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace PetshopApp2019.Infrastructure.SQLData.Repositories
{
    public class OrderRepository : IOrderRepository

    {
        UmbrellaShopContext context;
        public OrderRepository(UmbrellaShopContext ctx) {
            context = ctx;
        }
        public Order Create(Order Order)
        {
            context.Orders.Add(Order);
            return Order;
        }

        public Order Delete(int id)
        {
            var Order = ReadByID(id);
            context.Remove(Order);
            return Order;
        }

        public Order ReadByID(int id)
        {
            var Order = context.Orders.Find(id);
            return Order;
        }

        public IEnumerable<Order> ReadOrders()
        {
            return context.Orders
                .Include(c => c.Customer)
                .Include(c => c.OrderUmbrellas)
                .ToList();
        }

        public Order Update(int id, Order Order)
        {
            if (Delete(id) != null) {
                Order.Id = id;
                context.Orders.Add(Order);
                return Order;
            }
            return null;
        }
    }
}
