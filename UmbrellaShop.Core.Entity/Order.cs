using System;
using System.Collections.Generic;
using System.Text;

namespace UmbrellaShop.Core.Entity
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderPlaced { get; set; }
        public DateTime OrderShipped { get; set; }
        public string BillingAddress { get; set; }
        public Customer Customer { get; set; }
        public IList<OrderUmbrella> OrderUmbrellas { get; set; }
    }
   
}
