using PulseActiveShop.Core.Entities;
using PulseActiveShop.Core.Interfaces.Core;

namespace PulseActiveShop.Core.Interfaces.Repository;

public interface IReadRepository<TEntity, TEntityCollection>
    where TEntity : BaseEntity, IAggregateRoot
    where TEntityCollection : BaseEntityCollection<TEntity>
{
    Task<int> CountAsync();

    Task<bool> ExistsAsync(int id);
    
    Task<TEntity?> FindAsync(int id);

    Task<TEntityCollection> GetAllAsync(int page, int pageSize);

    Task<TEntityCollection> FilterAsync(int[] ids, int page = 1, int pageSize = int.MaxValue);

}
