using PulseActiveShop.Core.Interfaces.Core;

namespace PulseActiveShop.Core.Entities
{
    public class Product : BaseEntity, IAggregateRoot
    {
        public Product()
        {

        }

        public Product(
            string name,
            decimal price,
            int productTypeId,
            int brandId,
            string description,
            string? pictureUri = null)
        {
            Name = name;
            Description = description;
            Price = price;
            PictureUri = pictureUri;
            ProductTypeId = productTypeId;
            BrandId = brandId;
        }

        public string Name { get; private set; } = null!;

        public string Description { get; private set; }

        public decimal Price { get; private set; }

        public string? PictureUri { get; private set; }

        public int ProductTypeId { get; private set; }

        public int BrandId { get; private set; }

        public void UpdateDetails(ProductDetails details)
        {
            ArgumentNullException.ThrowIfNull(details, nameof(details));

            this.Name = details.Name;
            this.Description = details.Description;
            this.Price = details.Price;
        }

        public void UpdateBrand(int brandId)
        {
            if (brandId < 0)
                throw new ArgumentOutOfRangeException(nameof(brandId));

            this.BrandId = brandId;
        }

        public void UpdateType(int productTypeId)
        {
            if (productTypeId < 0)
                throw new ArgumentOutOfRangeException(nameof(productTypeId));

            this.ProductTypeId = productTypeId;
        }

        public void UpdatePictureUri(string pictureName)
        {
            if (string.IsNullOrEmpty(pictureName))
            {
                this.PictureUri = string.Empty;
                return;
            }
            //TODO: replace
            PictureUri = $"images\\products\\{pictureName}";
        }
    }

    public class ProductCollection : BaseEntityCollection<Product>
    {

    }
}
