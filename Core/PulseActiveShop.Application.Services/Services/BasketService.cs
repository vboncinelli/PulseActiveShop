using Microsoft.Extensions.Logging;
using PulseActiveShop.Core.Entities;
using PulseActiveShop.Core.Exceptions;
using PulseActiveShop.Core.Interfaces.Repository;
using PulseActiveShop.Core.Interfaces.Services;

namespace PulseActiveShop.Application.Services.Services
{
    public class BasketService : BaseService<Basket, BasketCollection, BasketService>, IBasketService
    {
        private readonly IBasketRepository _basketRepository;

        public BasketService(IBasketRepository basketRepository, ILogger<BasketService> logger) : base(logger)
        {
            _basketRepository = basketRepository ?? throw new ArgumentNullException(nameof(basketRepository));
        }

        public async Task<Basket> AddItemToBasketAsync(Guid customerId, Guid productId, decimal price, int quantity = 1)
        {
            try
            {
                var basket = await _basketRepository.FindBasketByUserIdAsync(customerId);

                if (basket == null)
                {
                    basket = new Basket(customerId);
                    await _basketRepository.AddAsync(basket);
                }

                basket.AddItem(productId, price, quantity);

                await _basketRepository.UpdateAsync(basket);

                return basket;
            }
            catch (AppException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message, ex);
            }
        }

        public async Task DeleteBasketAsync(Guid basketId)
        {
            try
            {
                await this._basketRepository.DeleteAsync(basketId);
            }
            catch (AppException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message, ex);
            }
        }

        public async Task<Basket?> FindBasketByCustomerIdAsync(Guid customerId)
        {
            try
            {
                return await this._basketRepository.FindBasketByUserIdAsync(customerId);
            }
            catch (AppException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message, ex);
            }
        }

        public async Task<Basket?> FindBasketByCustomerNameAsync(string username)
        {
            try
            {
                return await this._basketRepository.FindBasketByUsernameAsync(username);
            }
            catch (AppException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message, ex);
            }
        }

        public async Task<Basket> SetQuantitiesAsync(Guid basketId, Dictionary<string, int> quantities)
        {
            try
            {
                var basket = await _basketRepository.FindAsync(basketId);

                if (basket == null) throw new EntityNotFoundException($"Unable to find a basket with Id {basketId}");

                foreach (var item in basket.Items)
                {
                    if (quantities.TryGetValue(item.Id.ToString(), out var quantity))
                    {
                        if (_logger != null) _logger.LogInformation($"Updating quantity of item ID:{item.Id} to {quantity}.");
                        item.SetQuantity(quantity);
                    }
                }
                basket.RemoveEmptyItems();

                await _basketRepository.UpdateAsync(basket);

                return basket;
            }
            catch (AppException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message, ex);
            }
        }

        public Task<Basket> TransferBasketAsync(Guid anonymousId, Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}
