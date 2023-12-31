using PulseActiveShop.Application.Services.Utilities;
using PulseActiveShop.Core.Entities;
using PulseActiveShop.Core.Exceptions;
using PulseActiveShop.Core.Interfaces.Repository;
using PulseActiveShop.Core.Interfaces.Services;

namespace PulseActiveShop.Application.Services
{
    public class OrderService : BaseService, IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly IBasketRepository _basketRepository;
        private readonly IUriComposer _uriComposer;

        public OrderService(
            IOrderRepository orderRepository, 
            IProductRepository productRepository, 
            IBasketRepository basketRepository,
            IUriComposer uriComposer)
        {
            this._orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            this._productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            this._basketRepository = basketRepository ?? throw new ArgumentNullException(nameof(basketRepository));
            this._uriComposer = uriComposer ?? throw new ArgumentNullException(nameof(uriComposer));
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
    }
}
