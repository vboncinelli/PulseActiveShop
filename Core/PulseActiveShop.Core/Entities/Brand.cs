using PulseActiveShop.Core.Interfaces.Core;
namespace PulseActiveShop.Core.Entities
{
    public class Brand : BaseEntity, IAggregateRoot
    {
        public Brand() { }

        public Brand(string name)
        {
            this.Name = name;
        }

        public Brand(Guid id, string name): this(name)
        {
            this.Id = id;
        }

        public string Name { get; private set; } = null!;
    }

    public class BrandCollection : BaseEntityCollection<Brand> { }
}
