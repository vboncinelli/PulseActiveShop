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
            string productTypeName,
            int brandId,
            string brandName,
            string? description = null,
            string? pictureUri = null)
        {
            Name = name;
            Description = description;
            Price = price;
            PictureUri = pictureUri;
            ProductTypeId = productTypeId;
            ProductTypeName = productTypeName;
            BrandId = brandId;
            BrandName = brandName;
        }

        public string Name { get; private set; } = null!;

        public string? Description { get; private set; }

        public decimal Price { get; private set; }

        public string? PictureUri { get; private set; }

        public int ProductTypeId { get; private set; }

        public string ProductTypeName { get; private set; } = null!;

        public int BrandId { get; private set; }

        public string BrandName { get; private set; } = null!;

        public void UpdateDetails(ProductDetails details)
        {
            ArgumentNullException.ThrowIfNull(details, nameof(details));

            Name = details.Name;
            Description = details.Description;
            Price = details.Price;
        }

        public void UpdateBrand(Brand brand)
        {
            if (brand == null)
                throw new ArgumentNullException(nameof(brand));

            BrandId = brand.Id;
            BrandName = brand.Name;
        }

        public void UpdateType(ProductType type)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type));

            ProductTypeId = type.Id;
            ProductTypeName = type.Type;
        }

        public void UpdatePictureUri(string pictureName)
        {
            if (string.IsNullOrEmpty(pictureName))
            {
                PictureUri = string.Empty;
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
