using System.Text.Json.Serialization;

namespace PulseActiveShop.Api.Entities
{
    public class BasketItem : BaseApiEntity
    {
        public decimal UnitPrice { get; set; }

        public int Quantity { get; set; }

        public Product? Product { get; set; }

        public int? BasketId { get; set; }
    }
}
