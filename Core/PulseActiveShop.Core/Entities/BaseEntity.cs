namespace PulseActiveShop.Core.Entities
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
    }

    public abstract class BaseEntityCollection<TEntity> : List<TEntity>
        where TEntity : BaseEntity
    {
        public int? Page { get; set; }

        public int? PageSize { get; set;}

        public int? TotalItemCount { get; set; }
    }
}
