using PulseActiveShop.Core.Entities;

namespace PulseActiveShop.Core.Interfaces.Services
{
    public interface IProductService : IService
    {
        Task<Product> AddProductAsync(Product product);

        Task<Product?> FindProductAsync(Guid id);

        Task<ProductCollection> GetAllProductsAsync(int page = 1, int pageSize = 25);

        Task<Product> UpdateProductBrandAsync(Guid productId, Guid brandId);

        Task<Product> UpdateProductDetailsAsync(Guid productId, ProductDetails productDetails);
        
        Task DeleteAsync(Guid id);
    }
}
