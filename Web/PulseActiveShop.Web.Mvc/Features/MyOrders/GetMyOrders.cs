using MediatR;
using Microsoft.eShopWeb.Web.ViewModels;

namespace PulseActiveShop.Web.Mvc.Features;

public class GetMyOrders : IRequest<IEnumerable<OrderViewModel>>
{
    public string UserName { get; set; }

    public GetMyOrders(string userName)
    {
        UserName = userName;
    }
}
