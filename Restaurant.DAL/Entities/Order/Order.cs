using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.DAL.Entities.Order
{
    public class Order : BaseEntity
    {
        public Order()
        {

        }
        public Order(string buyerEmail, string shipToAddress,
                      List<OrderItem> items,
                     decimal total)
        {
            BuyerEmail = buyerEmail;
            ShipToAddress = shipToAddress;
            Items = items;
            Total = total;
        }

        public string BuyerEmail { get; set; }
        public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.Now;
        public string ShipToAddress { get; set; }
        public List<OrderItem> Items { get; set; }
        public decimal Total { get; set; }
        
    }
}
