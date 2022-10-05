using System;
using System.Collections.Generic;

namespace Restaurant.APIs.DTOs
{
    public class OrderToReturnDto
    {
        public int Id { get; set; }
        public string BuyerEmail { get; set; }
        public DateTimeOffset OrderDate { get; set; }
        public string ShipToAddress { get; set; }
        public List<OrderItemDto> Items { get; set; }
        public decimal Total { get; set; }
    }
}
