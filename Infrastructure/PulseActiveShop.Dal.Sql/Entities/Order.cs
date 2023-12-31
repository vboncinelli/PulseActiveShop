namespace PulseActiveShop.Dal.Sql.Entities
{
    public class Order : BaseDalEntity
    {
        public int? CustomerId { get; set; }

        public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.Now;

        public Address? ShipToAddress { get; set; }

        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
