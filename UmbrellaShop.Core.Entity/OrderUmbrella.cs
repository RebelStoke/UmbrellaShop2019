using System;
using System.Collections.Generic;
using System.Text;

namespace UmbrellaShop.Core.Entity
{
    public class OrderUmbrella
    {
        public int OrderId { get; set; }
        public Order Order { get; set; }

        public int UmbrellaId { get; set; }
        public Umbrella Umbrella { get; set; }
    }
}
