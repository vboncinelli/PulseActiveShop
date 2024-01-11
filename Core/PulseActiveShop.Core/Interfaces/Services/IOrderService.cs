using PulseActiveShop.Core.Entities;

namespace PulseActiveShop.Core.Interfaces.Services;

public interface IOrderService : IService
{
    Task CreateOrderAsync(Guid basketId, Address shippingAddress);

    Task<OrderCollection> GetCustomerOrdersAsync(Guid customerId, int page = 1, int pageSize = 25);

    Task<Order?> GetOrderAsync(Guid orderId);

    Task<Order> AddOrderItemsAsync(Guid orderId, List<OrderItem> orderItems);

    Task<Order> RemoveOrderItemAsync(Guid orderId, Guid orderItemId);
}
