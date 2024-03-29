﻿using PulseActiveShop.Core.Entities;
using PulseActiveShop.Core.Interfaces.Core;

namespace PulseActiveShop.Core.Interfaces.Repository;

public interface IRepository<TEntity, TEntityCollection> : IReadRepository<TEntity, TEntityCollection>
    where TEntity : BaseEntity, IAggregateRoot
    where TEntityCollection : BaseEntityCollection<TEntity>
{
    Task<TEntity> AddAsync(TEntity entity);

    Task AddBulkAsync(TEntityCollection collection);
    
    Task DeleteAsync(Guid id);
    
    Task<TEntity> UpdateAsync(TEntity entity);
    
    Task UpdateBulkAsync(TEntityCollection collection);
}

