namespace PulseActiveShop.Dal.Sql.Entities
{
    public class Address : BaseDalEntity
    {
        public int? UserId { get; set; }

        public string? Street { get; set; }
        
        public string? City { get; set; }
        
        public string? StateOrProvince { get; set; }
        
        public string? Country { get; set; }
        
        public string? ZipCode { get; set; }

        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

        public virtual User User { get; set; } = null!;
    }
}
