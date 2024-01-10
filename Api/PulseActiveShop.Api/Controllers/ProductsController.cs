using Microsoft.AspNetCore.Mvc;
using PulseActiveShop.Api.Entities;
using PulseActiveShop.Api.Mappers;
using PulseActiveShop.Core.Interfaces.Services;

namespace PulseActiveShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(IProductService productService, ILogger<ProductsController> logger)
        {
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindProductAsync(int id)
        {
            try
            {
                var product = await this._productService.FindProductAsync(id);

                if (product == null)
                    return NotFound();

                return Ok(product);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.Message, ex);

                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] int page = 1, [FromQuery] int pageSize = 25)
        {
            try
            {
                var products = await this._productService.GetAllProductsAsync(page, pageSize);

                return Ok(products);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.Message, ex);

                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] Product product)
        {
            try
            {
                var newProduct = await this._productService.AddProductAsync(product.ToDomain());

                return Ok(newProduct);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.Message, ex);

                throw;
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDetailsAsync([FromBody] ProductDetails details)
        {
            try
            {
                var updatedProduct = await this._productService.UpdateProductDetailsAsync(details.ProductId!.Value, details.ToDomain());

                return Ok(updatedProduct);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.Message, ex);

                throw;
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                await this._productService.DeleteAsync(id);

                return Ok();
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.Message, ex);

                throw;
            }
        }
    }
}
