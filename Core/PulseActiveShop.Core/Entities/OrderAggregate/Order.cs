namespace PulseActiveShop.Core.Entities
{
    public class Order : BaseEntity
    {
        public string? CustomerId { get; set; }

        public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.Now;

        public Address? ShipToAddress { get; set; }

        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
