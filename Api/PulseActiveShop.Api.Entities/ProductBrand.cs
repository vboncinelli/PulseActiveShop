namespace PulseActiveShop.Api.Entities
{
    public class ProductBrand : BaseApiEntity
    {
        public string? Name { get; set; }
    }

    public class ProductBrandCollection : BaseApiEntityCollection<ProductBrand> { }
}
