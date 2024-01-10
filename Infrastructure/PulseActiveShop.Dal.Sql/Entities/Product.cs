namespace PulseActiveShop.Dal.Sql.Entities
{
    public class Product : BaseDalEntity
    {
        public required string Name { get; set; }

        public required string Description { get; set; }

        public required decimal Price { get; set; }

        public string? PictureUri { get; set; }

        public required int ProductTypeId { get; set; }

        public ProductType? ProductType { get; set; }

        public required int BrandId { get; set; }

        public Brand? Brand { get; set; }

        public virtual ICollection<BasketItem> BasketItems { get; set; } = new List<BasketItem>();

    }
}
