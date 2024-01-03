using PulseActiveShop.Core.Interfaces.Core;

namespace PulseActiveShop.Core.Entities
{
    public class ProductType : BaseEntity, IAggregateRoot
    {
        public string Type { get; private set; } = null!;

        public ProductType()
        {

        }

        public ProductType(string type)
        {
            this.Type = type;
        }
    }

    public class ProductTypeCollection : BaseEntityCollection<ProductType> { }
}
