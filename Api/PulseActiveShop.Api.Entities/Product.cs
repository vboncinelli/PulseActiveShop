using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PulseActiveShop.Api.Entities
{
    public class Product : BaseApiEntity
    {
        [Required]
        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        [Required]
        public decimal? Price { get; set; }

        public string? PictureUri { get; set; }

        [Required]
        public int ProductTypeId { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ProductType? ProductType { get; set; }

        public int BrandId { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ProductBrand? Brand { get; set; }
    }

    public class ProductCollection : BaseApiEntityCollection<Product> { }
}
