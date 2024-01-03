namespace PulseActiveShop.Dal.Sql.Entities
{
    public class Address : BaseDalEntity
    {
        public required int UserId { get; set; }

        public required string Street { get; set; }
        
        public required string City { get; set; }
        
        public required string StateOrProvince { get; set; }
        
        public required string Country { get; set; }
        
        public required string ZipCode { get; set; }

        public User? User { get; set; }
    }
}
