using PulseActiveShop.Core.Entities;

namespace PulseActiveShop.Dal.Sql.Entities
{
    public class OrderItem : BaseDalEntity
    {
        public int? ProductId { get; set; } 

        public string? ProductName { get; set; }
        
        public string? PictureUri { get; set; }

        public decimal? UnitPrice { get; private set; }

        public int? Units { get; private set; }
    }
}
