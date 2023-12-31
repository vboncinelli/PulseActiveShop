using PulseActiveShop.Core.Entities;

namespace PulseActiveShop.Core.Interfaces.Services;

public interface IOrderService : IService
{
    Task CreateOrderAsync(int basketId, Address shippingAddress);
}
