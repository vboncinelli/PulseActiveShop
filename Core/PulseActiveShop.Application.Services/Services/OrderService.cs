using Microsoft.Extensions.Logging;
using PulseActiveShop.Application.Services.Utilities;
using PulseActiveShop.Core.Entities;
using PulseActiveShop.Core.Exceptions;
using PulseActiveShop.Core.Interfaces.Repository;
using PulseActiveShop.Core.Interfaces.Services;

namespace PulseActiveShop.Application.Services
{
    public class OrderService : BaseService<Order, OrderCollection, OrderService>, IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly IBasketRepository _basketRepository;
        private readonly IUriComposer _uriComposer;

        public OrderService(
            IOrderRepository orderRepository,
            IProductRepository productRepository,
            IBasketRepository basketRepository,
            IUriComposer uriComposer,
            ILogger<OrderService> logger) : base(logger)
        {
            this._orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            this._productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            this._basketRepository = basketRepository ?? throw new ArgumentNullException(nameof(basketRepository));
            this._uriComposer = uriComposer ?? throw new ArgumentNullException(nameof(uriComposer));
        }

        public async Task<Order?> GetOrderAsync(int orderId)
        {
            try
            {
                return await this._orderRepository.FindAsync(orderId);
            }
            catch (AppException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new AppException("An error occurred while creating an order", ex);
            }
        }

        public async Task<OrderCollection> GetCustomerOrdersAsync(int customerId, int page = 1, int pageSize = 25)
        {
            try
            {
                return await this._orderRepository.GetCustomerOrdersAsync(customerId, page, pageSize);
            }
            catch (AppException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new AppException("An error occurred while creating an order", ex);
            }
        }

        public async Task CreateOrderAsync(int basketId, Address shippingAddress)
        {
            try
            {
                var basket = await _basketRepository.FindAsync(basketId) ?? throw new EntityNotFoundException("Basket");

                var productIds = basket.Items.Select(item => item.ProductId).ToArray();

                var products = await _productRepository.FilterAsync(productIds);

                var items = basket.Items.Select(basketItem =>
                {
                    var product = products.First(c => c.Id == basketItem.ProductId);

                    var itemOrdered = new ProductOrdered(product.Id, product.Name!, _uriComposer.ComposePictureUri(product.PictureUri));

                    var orderItem = new OrderItem(itemOrdered, basketItem.UnitPrice, basketItem.Quantity);

                    return orderItem;

                }).ToList();

                var order = new Order(basket.CustomerId, shippingAddress, items);

                await _orderRepository.AddAsync(order);
            }
            catch (AppException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new AppException("An error occurred while creating an order", ex);
            }
        }

        public async Task<Order> AddOrderItemsAsync(int orderId, List<OrderItem> orderItems)
        {
            try
            {
                var order = await this._orderRepository.FindAsync(orderId);

                if (order == null)
                    throw new EntityNotFoundException($"Order with Id {orderId} not found");

                order.AddOrderItems(orderItems);

                return await this._orderRepository.UpdateAsync(order);
            }
            catch (AppException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new AppException("An error occurred while creating an order", ex);
            }
        }

        public async Task<Order> RemoveOrderItemAsync(int orderId, int orderItemId)
        {
            try
            {
                var order = await this._orderRepository.FindAsync(orderId);

                if (order == null)
                    throw new EntityNotFoundException($"Order with Id {orderId} not found");

                order.RemoveOrderItem(orderItemId);

                return await this._orderRepository.UpdateAsync(order);
            }
            catch (AppException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new AppException("An error occurred while creating an order", ex);
            }
        }
    }
}
