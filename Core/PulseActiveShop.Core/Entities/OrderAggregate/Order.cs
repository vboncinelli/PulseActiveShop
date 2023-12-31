﻿namespace PulseActiveShop.Core.Entities
{
    public class Order : BaseEntity
    {
        public int? CustomerId { get; set; }

        public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.Now;

        public Address? ShipToAddress { get; set; }

        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

        public Order()
        {

        }

        public Order(int? customerId, Address? shipToAddress, List<OrderItem> orderItems)
        {
            this.CustomerId = customerId;
            this.ShipToAddress = shipToAddress;
            this.OrderItems = orderItems;
        }
    }

    public class OrderCollection : BaseEntityCollection<Order>
    {

    }
}
