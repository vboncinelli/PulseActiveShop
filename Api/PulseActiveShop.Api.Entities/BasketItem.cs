using System.ComponentModel.DataAnnotations;

namespace PulseActiveShop.Api.Entities
{
    public class BasketItem : BaseApiEntity
    {
        [Required]
        public decimal UnitPrice { get; set; }

        public int Quantity { get; set; } = 1;

        [Required]
        public Guid ProductId { get; set; }

        public Product? Product { get; set; }

        public Guid? BasketId { get; set; }
    }
}
