using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UmbrellaShop.Core.DomainService;
using UmbrellaShop.Core.Entity;

namespace UmbrellaShop.Infrastructure.SQLData.Repositories
{
   public  class OrderRepository : IOrderRepository
    {
        private readonly UmbrellaShopContext _context;

        public OrderRepository(UmbrellaShopContext context)
        {
            _context = context;
        }

        

        public Order CreateOrder(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
            return order;
        }

        public Order Delete(int id)
        {

            Order o = _context.Remove(new Order() { id = id }).Entity;
            _context.SaveChanges();
            return o;
        }

        public IEnumerable<Order> ReadAllOrders()
        {
           return _context.Orders.ToList();
        }

        public IEnumerable<Order> ReadById(int id)
        {
            return _context.Orders.ToList();
        }

        public Order Update(Order order)
        { 
            _context.Orders.Update(order);
            _context.SaveChanges();
            return order;
        }
    }
}
