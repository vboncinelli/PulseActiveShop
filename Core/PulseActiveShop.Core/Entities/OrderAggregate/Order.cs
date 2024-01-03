using PulseActiveShop.Core.Interfaces.Core;

namespace PulseActiveShop.Core.Entities
{
    public class Order : BaseEntity, IAggregateRoot
    {
        public int? CustomerId { get; private set; }

        public DateTime OrderDate { get; private set; } = DateTime.UtcNow;

        public Address? ShipToAddress { get; private set; }

        public List<OrderItem> OrderItems { get; private set; } = new List<OrderItem>();


        public Order()
        {

        }

        public Order(int? customerId, Address? shipToAddress, List<OrderItem> orderItems)
        {
            this.CustomerId = customerId;
            this.ShipToAddress = shipToAddress;
            this.OrderItems = orderItems;
        }

        public decimal GetTotal()
        {
            var total = 0m;

            foreach (var item in this.OrderItems)
            {
                total += item.UnitPrice * item.Units;
            }

            return total;
        }
    }

    public class OrderCollection : BaseEntityCollection<Order>
    {

    }
}
