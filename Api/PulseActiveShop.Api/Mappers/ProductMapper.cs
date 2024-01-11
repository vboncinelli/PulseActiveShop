using ApiEntities = PulseActiveShop.Api.Entities;
using Domain = PulseActiveShop.Core.Entities;

namespace PulseActiveShop.Api.Mappers
{
    public static class ProductMapper
    {
        public static Domain.Product ToDomain(this ApiEntities.Product product)
        {
            var entity = new Domain.Product(
                name: product.Name,
                price: product.Price!.Value,
                productTypeId: product.ProductTypeId,
                brandId: product.BrandId,
                description: product.Description);

            entity.Id = product.Id;

            return entity;
        }

        public static Domain.ProductDetails ToDomain(this ApiEntities.ProductDetails productDetails)
        {
            var entity = new Domain.ProductDetails(productDetails.Name, productDetails.Description, productDetails.Price);

            return entity;
        }

        public static ApiEntities.Product? ToApi(this Domain.Product? product)
        {
            if (product == null) return null;

            var entity = new ApiEntities.Product()
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                ProductTypeId = product.ProductTypeId,
                BrandId = product.BrandId,
                Description = product.Description
            };

            return entity;
        }

        public static ApiEntities.ProductDetails? ToApi(this Domain.ProductDetails? productDetails)
        {
            if (productDetails == null) return null;

            var entity = new ApiEntities.ProductDetails()
            {
                Name = productDetails.Name,
                Description = productDetails.Description,
                Price = productDetails.Price,
            };

            return entity;
        }

        public static List<ApiEntities.Product> ToApi(this Domain.ProductCollection collection)
        {
            var items = new List<ApiEntities.Product>();
            
            foreach (var item in collection)
                items.Add(item.ToApi()!);
            
            return items;
        }
    }
}
