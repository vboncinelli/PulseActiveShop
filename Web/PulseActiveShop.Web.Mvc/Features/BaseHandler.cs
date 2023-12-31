using MediatR;
using Microsoft.eShopWeb.Web.ViewModels;

namespace PulseActiveShop.Web.Mvc.Features
{
    public abstract class BaseHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {

        protected readonly string _baseUrl;

        public BaseHandler(IConfiguration configuration)
        {
            this._baseUrl = configuration["ApiBaseUrl"] ?? throw new ArgumentNullException(nameof(configuration));
        }

        public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
    }
}
