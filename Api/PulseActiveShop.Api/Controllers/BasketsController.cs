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


        [HttpPost]
        public async Task<Basket?> AddItemToBasket(Guid customerId, [FromBody] BasketItem item)
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

        [HttpPut("/quantities")]
        public async Task SetQuantities(Guid basketId, [FromBody] Dictionary<string, int> quantities)
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
