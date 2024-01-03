namespace PulseActiveShop.Dal.Sql.Entities
{
    public class User : BaseDalEntity
    {
        public string? Username { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }

        public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    }
}
