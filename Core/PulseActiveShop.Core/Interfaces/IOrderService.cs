using PulseActiveShop.Core.Entities;

namespace PulseActiveShop.Core.Interfaces;

public interface IOrderService
{
    Task CreateOrderAsync(int basketId, Address shippingAddress);
}
