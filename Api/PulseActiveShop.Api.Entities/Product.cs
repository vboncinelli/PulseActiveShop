using System.Text.Json.Serialization;

namespace PulseActiveShop.Api.Entities
{
    public class Product : BaseApiEntity
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("price")]
        public decimal? Price { get; set; }

        [JsonPropertyName("pictureUri")]
        public string? PictureUri { get; set; }

        [JsonPropertyName("productType")]
        public ProductType? ProductType { get; set; }

        [JsonPropertyName("productBrand")]
        public ProductBrand? ProductBrand { get; set; }
    }

    public class ProductCollection : BaseApiEntityCollection<Product> { }
}
