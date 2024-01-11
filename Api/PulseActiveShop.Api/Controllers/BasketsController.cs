using Microsoft.AspNetCore.Mvc;
using PulseActiveShop.Api.Entities;
using PulseActiveShop.Api.Mappers;
using PulseActiveShop.Core.Interfaces.Services;

namespace PulseActiveShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketsController : ControllerBase
    {
        private readonly IBasketService _basketService;
        private readonly ILogger<BasketsController> _logger;

        public BasketsController(IBasketService basketService, ILogger<BasketsController> logger)
        {
            this._basketService = basketService ?? throw new ArgumentNullException(nameof(basketService));
            this._logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }


        [HttpGet("/customer/id/{customerId}")]
        public async Task<IActionResult> GetBasketByCustomerIdAsync(Guid customerId)
        {
            try
            {
                var basket = await this._basketService.FindBasketByCustomerIdAsync(customerId);

                if (basket == null) return NotFound();

                return Ok(basket.ToApi());
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.Message, ex);

                throw;
            }
        }

        [HttpGet("/customer/name/{customerName}")]
        public async Task<IActionResult> GetBasketByCustomerNameAsync(string customerName)
        {
            try
            {
                var basket = await this._basketService.FindBasketByCustomerNameAsync(customerName);

                if (basket == null) return NotFound();

                return Ok(basket.ToApi());
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.Message, ex);

                throw;
            }
        }

        [HttpPost]
        public async Task<Basket?> AddItemToBasketAsync(Guid customerId, [FromBody] BasketItem item)
        {
            try
            {
                var updatedBasket = await this._basketService.AddItemToBasketAsync(customerId, item.ProductId, item.UnitPrice, item.Quantity);

                return updatedBasket.ToApi();
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.Message, ex);

                throw;
            }
        }

        /// <summary>
        /// Update the items quantity in the basket.
        /// </summary>
        /// <param name="basketId"></param>
        /// <param name="quantities">A dictionary of productId and related quantity</param>
        /// <returns>A newly created TodoItem</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /<basketId>
        ///     {
        ///        "<productId>": "<guid>",
        ///        "<productId>": "<guid>",
        ///        "<productId>": "<guid>"
        ///     }
        ///
        /// </remarks>
        [HttpPut("/{basketId}/quantities")]
        public async Task SetQuantitiesAsync(Guid basketId, [FromBody] Dictionary<string, int> quantities)
        {
            try
            {
                await this._basketService.SetQuantitiesAsync(basketId, quantities);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.Message, ex);

                throw;
            }
        }

        [HttpDelete]
        public async Task DeleteBasketAsync(Guid basketId)
        {
            try
            {
                await this._basketService.DeleteBasketAsync(basketId);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.Message, ex);

                throw;
            }
        }
    }
}
