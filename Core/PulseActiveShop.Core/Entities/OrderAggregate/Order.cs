using PulseActiveShop.Core.Exceptions;
using PulseActiveShop.Core.Interfaces.Core;

namespace PulseActiveShop.Core.Entities
{
    public class Order : BaseEntity, IAggregateRoot
    {
        public Guid CustomerId { get; private set; }

        public DateTime OrderDate { get; private set; } = DateTime.UtcNow;

        public Address ShipToAddress { get; private set; } = null!;

        public List<OrderItem> OrderItems { get; private set; } = new List<OrderItem>();


        public Order()
        {

        }

        public Order(Guid customerId, Address shipToAddress, List<OrderItem> orderItems)
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

        public void AddOrderItems(List<OrderItem> items)
        {
            if (items.Count > 0)
            {
                foreach (var item in items)
                {
                    var existingItemIndex = this.OrderItems.FindIndex(e => e.ItemOrdered.ProductId == item.ItemOrdered.ProductId);

                    if (existingItemIndex < 0)
                        this.OrderItems.Add(item);
                    else
                        // in a real app this logic would be more complex and fine-grained
                        this.OrderItems[existingItemIndex].UpdateUnits(1);
                }
            }
        }
        
        public void RemoveOrderItem(Guid orderItemId)
        {
            var existingItemIndex = this.OrderItems.FindIndex(e => e.Id == orderItemId);

            if (existingItemIndex < 0)
                throw new EntityNotFoundException($"Order item with id {orderItemId} not found");

            this.OrderItems.RemoveAt(existingItemIndex);
        }
    }

    public class OrderCollection : BaseEntityCollection<Order>
    {

    }
}
