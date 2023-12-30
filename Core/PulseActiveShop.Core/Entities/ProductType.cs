namespace PulseActiveShop.Core.Entities
{
    public class ProductType : BaseEntity
    {
        public string Type { get; private set; }

        public ProductType(string type)
        {
            this.Type = type;
        }
    }
}
