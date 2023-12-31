using System.Text.Json.Serialization;

namespace PulseActiveShop.Api.Entities
{
    public class BasketItem : BaseApiEntity
    {
        [JsonPropertyName("unitPrice")]
        public decimal UnitPrice { get; set; }

        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }

        [JsonPropertyName("products")]
        public Product? Product { get; set; }

        [JsonPropertyName("basket")]
        public Basket? Basket { get; set; }
    }
}
