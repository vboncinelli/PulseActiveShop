namespace PulseActiveShop.Api.Entities
{
    public class OrderItem : BaseApiEntity
    {
        public int OrderId { get; set; }

        public ProductOrdered ItemOrdered { get; set; } = null!;

        public decimal UnitPrice { get; set; }

        public int Units { get; set; }
    }

    public class OrderItemCollection : BaseApiEntityCollection<OrderItem> { }
}
