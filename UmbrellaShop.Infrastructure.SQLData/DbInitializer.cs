﻿using UmbrellaShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace UmbrellaShop.Infrastructure.SQLData
{
    public class DbInitializer
    {
        public static void Seed(UmbrellaShopContext context)
        {
            var listOfUmbrellas = new List<Umbrella>();
            var listOfCustomer = new List<Customer>();
            var listOfOrders = new List<Order>();
            var listOfOrderUmbrella = new List<OrderUmbrella>();

            var Customer1 = new Customer { FirstName = "Dude", LastName = "Son", Address = "Dirty Street", Email = "dude.son@xD.com", PhoneNumber = "66 66 66 66" };
            var Customer2 = new Customer { FirstName = "Big", LastName = "Lebowski", Address = "Dirty Street", Email = "dude.son@xD.com", PhoneNumber = "66 66 66 66" };
            var Customer3 = new Customer { FirstName = "John", LastName = "Rambo", Address = "Dirty Street", Email = "dude.son@xD.com", PhoneNumber = "66 66 66 66" };
            var Customer4 = new Customer { FirstName = "Vincent", LastName = "Vega", Address = "Dirty Street", Email = "dude.son@xD.com", PhoneNumber = "66 66 66 66" };
            listOfCustomer.Add(Customer1);
            listOfCustomer.Add(Customer2);
            listOfCustomer.Add(Customer3);
            listOfCustomer.Add(Customer4);

            var Umbrella1 = new Umbrella { Brand = "Callaway", Color = "Brown", Size = 1, Price = 69, Type = "Straight" };
            var Umbrella2 = new Umbrella { Brand = "Wilson",  Color = "Black", Size = 2, Price = 98, Type = "Folding" };
            var Umbrella3 = new Umbrella { Brand = "Dunlop",  Color = "White", Size = 3, Price = 102, Type = "Artistic" };
            var Umbrella4 = new Umbrella { Brand = "MarryPoppins", Color = "Brown", Size = 1, Price = 39, Type = "Artistic" };
            var Umbrella5 = new Umbrella { Brand = "Dunlop",  Color = "Black", Size = 2, Price = 106, Type = "Straight" };
            var Umbrella6 = new Umbrella { Brand = "Wilson", Color = "White", Size = 3, Price = 78, Type = "Folding" };
            listOfUmbrellas.Add(Umbrella1);
            listOfUmbrellas.Add(Umbrella2);
            listOfUmbrellas.Add(Umbrella3);
            listOfUmbrellas.Add(Umbrella4);
            listOfUmbrellas.Add(Umbrella5);
            listOfUmbrellas.Add(Umbrella6);

            var Order1 = new Order { BillingAddress = "Void", Customer = Customer1, OrderPlaced = DateTime.Now, OrderShipped = DateTime.Now };
            var Order2 = new Order { BillingAddress = "Void", Customer = Customer2, OrderPlaced = DateTime.Now, OrderShipped = DateTime.Now };
            var Order3 = new Order { BillingAddress = "Void", Customer = Customer3, OrderPlaced = DateTime.Now, OrderShipped = DateTime.Now };
            var Order4 = new Order { BillingAddress = "Void", Customer = Customer4, OrderPlaced = DateTime.Now, OrderShipped = DateTime.Now };
            listOfOrders.Add(Order1);
            listOfOrders.Add(Order2);
            listOfOrders.Add(Order3);
            listOfOrders.Add(Order4);

            var OrderUmbrella1 = new OrderUmbrella {Order = Order1, Umbrella = Umbrella2 };
            listOfOrderUmbrella.Add(OrderUmbrella1);

            context.Umbrellas.AddRange(listOfUmbrellas);
            context.OrderUmbrellas.AddRange(listOfOrderUmbrella);
            context.Customers.AddRange(listOfCustomer);
            context.SaveChanges();
        }
    }
}