using PulseActiveShop.Core.Entities;

namespace PulseActiveShop.Core.Interfaces.Services
{
    public interface IProductService : IService
    {
        Task<Product> AddProductAsync(Product product);

        Task<Product?> FindProductAsync(int id);

        Task<ProductCollection> GetAllProductsAsync(int page = 1, int pageSize = 25);

        Task<Product> UpdateProductBrandAsync(int productId, int brandId);

        Task<Product> UpdateProductDetailsAsync(int productId, ProductDetails productDetails);
    }
}
