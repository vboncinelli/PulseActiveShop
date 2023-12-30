using PulseActiveShop.Core.Entities;

namespace PulseActiveShop.Core.Interfaces;

public interface IRepository<TEntity, TEntityCollection> : IReadRepository<TEntity, TEntityCollection>
    where TEntity : BaseEntity, new()
    where TEntityCollection: BaseEntityCollection<TEntity>, new()   
{

}

