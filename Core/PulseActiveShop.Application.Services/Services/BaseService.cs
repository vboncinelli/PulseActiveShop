
using Microsoft.Extensions.Logging;
using PulseActiveShop.Core.Entities;
using PulseActiveShop.Core.Interfaces.Core;
using PulseActiveShop.Core.Interfaces.Services;

namespace PulseActiveShop.Application.Services
{
    public abstract class BaseService<TEntity, TEntityCollection, TService> : IService
        where TEntity : BaseEntity, IAggregateRoot, new()
        where TEntityCollection : BaseEntityCollection<TEntity>, new()
    {
        protected readonly ILogger<TService> _logger;

        public BaseService(ILogger<TService> logger)
        {
            this._logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
    }
}
