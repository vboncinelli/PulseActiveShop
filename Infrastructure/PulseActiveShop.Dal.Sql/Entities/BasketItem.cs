namespace PulseActiveShop.Dal.Sql.Entities
{
    public class BasketItem : BaseDalEntity
    {
        public required decimal UnitPrice { get; set; }

        public required int Quantity { get; set; }

        public required Guid ProductId { get; set; }

        public Product? Product { get; set; }

        public required Guid BasketId { get; set; }

        public Basket? Basket { get; set; }
    }
}
