using Microsoft.AspNetCore.Mvc;
using PulseActiveShop.Api.Entities;
using PulseActiveShop.Api.Mappers;
using PulseActiveShop.Core.Interfaces.Services;

namespace PulseActiveShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly ILogger<OrdersController> _logger;

        public OrdersController(IOrderService orderService, ILogger<OrdersController> logger)
        {
            this._orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
            this._logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindAsync(Guid id)
        {
            try
            {
                var order = await this._orderService.GetOrderAsync(id);

                if (order is null) return NotFound();

                return Ok(order.ToApi());
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.Message, ex);

                throw;
            }
        }

        [HttpGet("/customer/{customerId}")]
        public async Task<IEnumerable<Order>> GetCustomerOrdersAsync(Guid customerId, [FromQuery] int page = 1, [FromQuery] int pageSize = 25)
        {
            try
            {
                var orders = await this._orderService.GetCustomerOrdersAsync(customerId, page, pageSize);

                return orders.ToApi();
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.Message, ex);

                throw;
            }
        }
    }
}
