using Microsoft.Extensions.Logging;
using PulseActiveShop.Core.Entities;
using PulseActiveShop.Core.Exceptions;
using PulseActiveShop.Core.Interfaces.Repository;
using PulseActiveShop.Core.Interfaces.Services;

namespace PulseActiveShop.Application.Services
{
    public class ProductService : BaseService<Product, ProductCollection, ProductService>, IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IBrandRepository _brandRepository;
        private readonly IProductTypeRepository _productTypeRepository;

        public ProductService(
            IProductRepository productRepository,
            IBrandRepository brandRepository,
            IProductTypeRepository productTypeRepository,
            ILogger<ProductService> logger) : base(logger)
        {
            this._productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            this._brandRepository = brandRepository ?? throw new ArgumentNullException(nameof(brandRepository));
            this._productTypeRepository = productTypeRepository ?? throw new ArgumentNullException(nameof(productTypeRepository));
        }

        public async Task<Product?> FindProductAsync(Guid id)
        {
            try
            {
                return await this._productRepository.FindAsync(id);
            }
            catch (AppException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new AppException("An error occurred while creating an order", ex);
            }
        }

        public async Task<ProductCollection> GetAllProductsAsync(int page = 1, int pageSize = 25)
        {
            try
            {
                return await this._productRepository.GetAllAsync(page, pageSize);
            }
            catch (AppException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new AppException("An error occurred while creating an order", ex);
            }
        }

        public async Task<Product> AddProductAsync(Product product)
        {
            try
            {
                return await this._productRepository.AddAsync(product);
            }
            catch (AppException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new AppException("An error occurred while creating an order", ex);
            }
        }

        public async Task<Product> UpdateProductDetailsAsync(Guid productId, ProductDetails productDetails)
        {
            try
            {
                var product = await this._productRepository.FindAsync(productId);

                if (product == null)
                    throw new EntityNotFoundException($"Product with id {productId} not found");

                product.UpdateDetails(productDetails);

                return await this._productRepository.UpdateAsync(product);
            }
            catch (AppException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new AppException("An error occurred while creating an order", ex);
            }
        }

        public async Task<Product> UpdateProductBrandAsync(Guid productId, Guid brandId)
        {
            try
            {
                var product = await this._productRepository.FindAsync(productId) ??
                    throw new EntityNotFoundException($"Product with id {productId} not found");

                var brand = await this._brandRepository.FindAsync(brandId) ??
                    throw new EntityNotFoundException($"Brand with id {brandId} not found");

                product.UpdateBrand(brandId);

                return await this._productRepository.UpdateAsync(product);
            }
            catch (AppException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new AppException("An error occurred while creating an order", ex);
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            try
            {
                await this._productRepository.DeleteAsync(id);
            }
            catch (AppException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new AppException("An error occurred while creating an order", ex);
            }
        }
    }
}
