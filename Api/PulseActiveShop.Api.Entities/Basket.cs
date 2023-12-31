using System.Text.Json.Serialization;

namespace PulseActiveShop.Api.Entities
{
    public class Basket : BaseApiEntity
    {
        [JsonPropertyName("customerId")]
        public string? CustomerId { get; set; }

        [JsonPropertyName("items")]
        public List<BasketItem> Items { get; set;} = new List<BasketItem>();
    }

    public class BasketCollection : BaseApiEntityCollection<Basket>
    {

    }
}
