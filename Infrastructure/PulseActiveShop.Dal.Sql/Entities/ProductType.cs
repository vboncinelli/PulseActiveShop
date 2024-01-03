namespace PulseActiveShop.Dal.Sql.Entities
{
    public class ProductType : BaseDalEntity
    {
        public string? Type { get; set; }

        public string? Description { get; set; }

        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
