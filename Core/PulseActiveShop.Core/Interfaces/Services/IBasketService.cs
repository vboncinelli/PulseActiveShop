using PulseActiveShop.Core.Entities;

namespace PulseActiveShop.Core.Interfaces.Services;

public interface IBasketService
{
    Task TransferBasketAsync(string anonymousId, string userName);

    Task<Basket> AddItemToBasket(string username, int catalogItemId, decimal price, int quantity = 1);

    Task SetQuantities(int basketId, Dictionary<string, int> quantities);

    Task DeleteBasketAsync(int basketId);
}
