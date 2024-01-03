using PulseActiveShop.Core.Entities;

namespace PulseActiveShop.Core.Interfaces.Services;

public interface IOrderService : IService
{
    Task CreateOrderAsync(int basketId, Address shippingAddress);

    Task<OrderCollection> GetCustomerOrders(int[] ids, int page = 1, int pageSize = 25);

    Task<Order?> GetOrderAsync(int orderId);

    Task<Order> AddOrderItemsAsync(int orderId, List<OrderItem> orderItems);

    Task<Order> RemoveOrderItemAsync(int orderId, int orderItemId);
}
