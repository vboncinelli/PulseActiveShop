using MediatR;
using Microsoft.eShopWeb.Web.ViewModels;

namespace PulseActiveShop.Web.Mvc.Features;

public class GetOrderDetails : IRequest<OrderDetailViewModel>
{
    public string UserName { get; set; }
    public int OrderId { get; set; }

    public GetOrderDetails(string userName, int orderId)
    {
        UserName = userName;
        OrderId = orderId;
    }
}
