using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.eShopWeb.Web.ViewModels;
using RestSharp;

namespace PulseActiveShop.Web.Mvc.Features;

public class GetOrderDetailsHandler : BaseHandler<GetOrderDetails, OrderDetailViewModel?>
{
    private readonly string _orderEndpoint = "/orders";

    public GetOrderDetailsHandler(IConfiguration configuration) : base(configuration)
    {
        
    }

    public override async Task<OrderDetailViewModel?> Handle(GetOrderDetails request, CancellationToken cancellationToken)
    {
        try
        {
            var client = new RestClient(this._baseUrl);
            var request2 = new RestRequest(this._orderEndpoint, Method.Get);
            client.GetAsync<>

            var spec = new OrderWithItemsByIdSpec(request.OrderId);
            var order = await _orderRepository.FirstOrDefaultAsync(spec, cancellationToken);

            if (order == null)
            {
                return null;
            }

            return new OrderDetailViewModel
            {
                OrderDate = order.OrderDate,
                OrderItems = order.OrderItems.Select(oi => new OrderItemViewModel
                {
                    PictureUrl = oi.ItemOrdered.PictureUri,
                    ProductId = oi.ItemOrdered.CatalogItemId,
                    ProductName = oi.ItemOrdered.ProductName,
                    UnitPrice = oi.UnitPrice,
                    Units = oi.Units
                }).ToList(),
                OrderNumber = order.Id,
                ShippingAddress = order.ShipToAddress,
                Total = order.Total()
            };
        }
        catch (Exception)
        {
            throw;
        }
    }
}
