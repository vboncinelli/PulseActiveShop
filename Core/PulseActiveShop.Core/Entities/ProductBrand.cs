using PulseActiveShop.Core.Interfaces.Core;
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
