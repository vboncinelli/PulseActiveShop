namespace PulseActiveShop.Api.Entities
{
    public abstract class BaseApiEntity
    {
        public int Id { get; set; }
    }

    public abstract class BaseApiEntityCollection<TEntity> : List<TEntity>
        where TEntity : BaseApiEntity, new()
    {
        public int Page { get; set; }

        public int PageSize { get; set; }

        public int TotalItemCount { get; set; }
    }
}
