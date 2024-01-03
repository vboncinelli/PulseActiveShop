namespace PulseActiveShop.Dal.Sql.Entities
{
    public class Order : BaseDalEntity
    {
        public int? CustomerId { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.UtcNow;

        public Address? ShipToAddress { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
