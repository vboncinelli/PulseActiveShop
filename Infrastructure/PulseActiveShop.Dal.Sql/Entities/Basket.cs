namespace PulseActiveShop.Dal.Sql.Entities
{
    public class Basket : BaseDalEntity
    {
        public required int CustomerId { get; set; }

        public ICollection<BasketItem> Items { get; set;} = new List<BasketItem>();
    }
}
