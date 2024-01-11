using System.ComponentModel.DataAnnotations;

namespace PulseActiveShop.Api.Entities
{
    public class ProductOrdered
    {
        [Required]
        public Guid ProductId { get; set; }

        [Required]
        public string ProductName { get; set; } = null!;

        public string? PictureUri { get; set; }
    }
}
