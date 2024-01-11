namespace PulseActiveShop.Dal.Sql.Entities
{
    public class Order : BaseDalEntity
    {
        public required Guid CustomerId { get; set; }

        public User? Customer { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.UtcNow;

        public required string Street { get; set; }

        public required string City { get; set; }

        public required string StateOrProvince { get; set; }

        public required string Country { get; set; }

        public required string ZipCode { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
