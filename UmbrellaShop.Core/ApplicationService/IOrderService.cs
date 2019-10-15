using System;
using System.Collections.Generic;
using System.Text;
using UmbrellaShop.Core.Entity;

namespace UmbrellaShop.Core.ApplicationService
{
    public interface IOrderService
    {

        List<Order> GetOrder();
        Order getOrderByID(int id);
        Order NewOrder(int id, DateTime OrderPlaced, DateTime OrderShipped, string BillingAddress, Customer customer);
        Order CreateOrder(Order Order);
        Order DeleteOrder(int id);
        Order UpdateOrder(int id, Order Order);

    }
}
