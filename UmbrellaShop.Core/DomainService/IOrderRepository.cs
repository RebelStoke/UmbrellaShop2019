using System;
using System.Collections.Generic;
using System.Text;
using UmbrellaShop.Core.Entity;

namespace UmbrellaShop.Core.DomainService
{
    public interface IOrderRepository
    {
        IEnumerable<Order> ReadOrders();
        Order Create(Order Order);
        Order Delete(int id);
        Order Update(int id, Order Order);
        Order ReadByID(int id);
    }
}
