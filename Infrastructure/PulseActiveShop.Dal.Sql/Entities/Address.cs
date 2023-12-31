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
    }
}
