using System.ComponentModel.DataAnnotations;

namespace PulseActiveShop.Api.Entities
{
    public class Order : BaseApiEntity
    {
        [Required]
        public Guid CustomerId { get; set; }

        public DateTime? OrderDate { get; set; }

        public Address? ShipToAddress { get; set; }

        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }

    public class OrderCollection : BaseApiEntityCollection<Order> 
    { 
    }
}
