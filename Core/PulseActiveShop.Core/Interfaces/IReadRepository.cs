
using PulseActiveShop.Core.Entities;

namespace PulseActiveShop.Core.Interfaces;

public interface IReadRepository<TEntity, TEntityCollection>
    where TEntity : BaseEntity, new()
    where TEntityCollection : BaseEntityCollection<TEntity>, new()
{
    Task<int> CountAsync();

    Task<bool> ExistsAsync(int id);
    
    Task<TEntityCollection> GetAllAsync(int page, int pageSize);
    
    Task<TEntity?> FindAsync(int id);
}
