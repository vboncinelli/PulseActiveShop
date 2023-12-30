using PulseActiveShop.Core.Interfaces;

namespace PulseActiveShop.Core.Entities
{
    public class Product : BaseEntity, IAggregateRoot
    {
        public Product(
            string name, 
            string description, 
            decimal price, 
            string pictureUri, 
            int productTypeId, 
            ProductType productType, 
            int productBrandId, 
            ProductBrand productBrand)
        {
            Name = name;
            Description = description;
            Price = price;
            PictureUri = pictureUri;
            ProductTypeId = productTypeId;
            ProductType = productType;
            ProductBrandId = productBrandId;
            ProductBrand = productBrand;
        }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public decimal Price { get; private set; }

        public string PictureUri { get; private set; }

        public int ProductTypeId { get; private set; }

        public ProductType? ProductType { get; private set; }

        public int ProductBrandId { get; private set; }

        public ProductBrand? ProductBrand { get; private set; }

        public void UpdateDetails(ProductDetails details)
        {
            ArgumentNullException.ThrowIfNull(details, nameof(details));

            Name = details.Name;
            Description = details.Description;
            Price = details.Price;
        }

        public void UpdateBrand(int productBrandId)
        {
            if (productBrandId < 0)
                throw new ArgumentException(nameof(productBrandId));

            ProductBrandId = productBrandId;
        }

        public void UpdateType(int productTypeId)
        {
            if (productTypeId < 0)
                throw new ArgumentException(nameof(productTypeId));

            ProductTypeId = productTypeId;
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
