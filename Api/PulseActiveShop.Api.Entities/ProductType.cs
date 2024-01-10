namespace PulseActiveShop.Api.Entities
{
    public class ProductType : BaseApiEntity
    {
        public string? Type { get; set; }
    }

    public class ProductTypeCollection : BaseApiEntityCollection<ProductType> { }
}
