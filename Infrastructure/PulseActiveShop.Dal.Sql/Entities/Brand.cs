namespace PulseActiveShop.Dal.Sql.Entities
{
    public class Brand : BaseDalEntity
    {
        public string? Name { get; set; }

        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
