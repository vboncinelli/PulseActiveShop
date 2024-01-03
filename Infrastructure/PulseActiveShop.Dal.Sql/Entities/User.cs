namespace PulseActiveShop.Dal.Sql.Entities
{
    public class User : BaseDalEntity
    {
        public required string Username { get; set; }

        public required string Email { get; set; }

        public required string Password { get; set; }
            
        public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    }
}
