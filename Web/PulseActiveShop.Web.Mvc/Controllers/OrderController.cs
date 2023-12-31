using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;

namespace PulseActiveShop.Web.Mvc.Controllers
{
    public class OrderController : Controller
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> MyOrders()
        {
            ArgumentNullException.ThrowIfNull(User?.Identity?.Name, nameof(User.Identity.Name));

            var viewModel = await _mediator.Send(new GetMyOrders(User.Identity.Name));

            return View(viewModel);
        }

        [HttpGet("{orderId}")]
        public async Task<IActionResult> Detail(int orderId)
        {
            ArgumentNullException.ThrowIfNull(User?.Identity?.Name, nameof(User.Identity.Name));

            var viewModel = await _mediator.Send(new GetOrderDetails(User.Identity.Name, orderId));

            if (viewModel == null)
            {
                return BadRequest("No such order found for this user.");
            }

            return View(viewModel);
        }
    }
}
