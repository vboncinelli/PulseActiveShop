namespace PulseActiveShop.Dal.Sql.Entities
{
    internal class BasketItem : BaseDalEntity
    {
        public decimal UnitPrice { get; set; }

        public int Quantity { get; set; }

        public int ProductId { get; set; }

        public Product? Product { get; set; }

        public int BasketId { get; set; }

        public Basket? Basket { get; set; }
    }
}
