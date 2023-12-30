using PulseActiveShop.Core.Interfaces;
namespace PulseActiveShop.Core.Entities
{
    public class ProductBrand : BaseEntity, IAggregateRoot
    {
        public ProductBrand(string brand)
        {
            this.Brand = brand;
        }

        public string Brand { get; private set; }
    }
}
