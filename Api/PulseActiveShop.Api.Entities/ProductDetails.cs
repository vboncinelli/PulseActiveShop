using System.ComponentModel.DataAnnotations;

namespace PulseActiveShop.Api.Entities
{
    public class ProductDetails
    {
        [Required]
        public int? ProductId {  get; set; }

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public string Description { get; set; } = null!;

        [Required]
        public decimal Price { get; set; }

    }
}
