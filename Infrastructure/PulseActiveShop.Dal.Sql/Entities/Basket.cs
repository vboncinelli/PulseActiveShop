namespace PulseActiveShop.Dal.Sql.Entities
{
    internal class Basket : BaseDalEntity
    {
        public string? CustomerId { get; set; }

        public ICollection<BasketItem> Items { get; set;} = new List<BasketItem>();
    }
}
