using PulseActiveShop.Core.Entities;

namespace PulseActiveShop.Core.Interfaces.Services;

public interface IBasketService
{
    Task<Basket?> FindBasketByCustomerNameAsync(string customerName);

    Task<Basket?> FindBasketByCustomerIdAsync(Guid customerId);

    Task<Basket> TransferBasketAsync(Guid anonymousId, Guid userId);

    Task<Basket> AddItemToBasketAsync(Guid userId, Guid catalogItemId, decimal price, int quantity = 1);

    Task<Basket> SetQuantitiesAsync(Guid basketId, Dictionary<string, int> quantities);

    Task DeleteBasketAsync(Guid basketId);
}
