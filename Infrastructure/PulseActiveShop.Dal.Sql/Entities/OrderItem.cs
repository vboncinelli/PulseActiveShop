using PulseActiveShop.Core.Entities;

namespace PulseActiveShop.Dal.Sql.Entities
{
    public class OrderItem : BaseDalEntity
    {
        public required int ProductId { get; set; }

        public required string ProductName { get; set; }
        
        public required string PictureUri { get; set; }

        public required decimal UnitPrice { get; set; }

        public required int Units { get; set; }
    }
}
