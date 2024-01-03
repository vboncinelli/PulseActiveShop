namespace PulseActiveShop.Dal.Sql.Entities
{
    public class Brand : BaseDalEntity
    {
        public required string Name { get; set; }

        public string? Description { get; set; }

        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
