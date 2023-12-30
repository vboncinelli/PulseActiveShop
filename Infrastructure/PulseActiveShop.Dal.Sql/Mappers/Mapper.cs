using AutoMapper;
using PulseActiveShop.Core.Entities;
using PulseActiveShop.Dal.Sql.Entities;

namespace PulseActiveShop.Dal.Sql.Mappers
{
    internal static class Mapper
    {
        internal static TEntity ToCore<TEntity, TDalEntity>(this TDalEntity entity)
        where TEntity : BaseEntity, new()
            where TDalEntity : BaseDalEntity, new()
        {
            return MapHelper.Mapper.Map<TEntity>(entity);
        }

        internal static TDalEntity ToDal<TDalEntity, TEntity>(this TEntity entity)
        where TEntity : BaseEntity, new()
        where TDalEntity : BaseDalEntity, new()
        {
            return MapHelper.Mapper.Map<TDalEntity>(entity);
        }
    }

    internal static class MapHelper
    {
        private static readonly MapperConfiguration _config;

        public static readonly IMapper Mapper;

        static MapHelper()
        {
            _config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<DalProfile>();
            });

            Mapper = _config.CreateMapper();
        }
    }
}
