using EF = PulseActiveShop.Dal.Sql.Entities;
using Domain = PulseActiveShop.Core.Entities;
using Microsoft.Extensions.Configuration;
using PulseActiveShop.Core.Interfaces.Repository;

namespace PulseActiveShop.Dal.Sql.Repositories
{
    public class BrandRepository : BaseRepository<Domain.Brand, Domain.BrandCollection, EF.Brand>, IBrandRepository
    {
        public BrandRepository(IConfiguration configuration) : base(configuration)
        {
        }

        protected override IQueryable<EF.Brand> GetDefaultOrdering(IQueryable<EF.Brand> query)
        {
            return query.OrderBy(e => e.Name);
        }

        protected override EF.Brand ToDal(Domain.Brand entity)
        {
            var dalEntity = new EF.Brand()
            {
                Id = entity.Id,
                Name = entity.Name,
            };

            return dalEntity;
        }

        protected override Domain.Brand? ToDomain(EF.Brand? dalEntity)
        {
            if (dalEntity == null) return null;

            return new Domain.Brand(dalEntity.Id, dalEntity.Name);
        }
    }
}
