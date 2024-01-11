using System.Text.Json.Serialization;

namespace PulseActiveShop.Api.Entities
{
    public class Basket : BaseApiEntity
    {
        public Guid CustomerId { get; set; }

        public List<BasketItem> Items { get; set;} = new List<BasketItem>();
    }

    public class BasketCollection : BaseApiEntityCollection<Basket>
    {

    }
}
