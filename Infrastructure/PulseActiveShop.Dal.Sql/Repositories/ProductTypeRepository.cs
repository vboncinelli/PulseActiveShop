using EF = PulseActiveShop.Dal.Sql.Entities;
using Domain = PulseActiveShop.Core.Entities;
using Microsoft.Extensions.Configuration;
using PulseActiveShop.Core.Interfaces.Repository;

namespace PulseActiveShop.Dal.Sql.Repositories
{
    public class ProductTypeRepository : BaseRepository<Domain.ProductType, Domain.ProductTypeCollection, EF.ProductType>, IProductTypeRepository
    {
        public ProductTypeRepository(IConfiguration configuration) : base(configuration)
        {
        }

        protected override IQueryable<EF.ProductType> GetDefaultOrdering(IQueryable<EF.ProductType> query)
        {
            return query.OrderBy(e => e.Type);
        }

        protected override EF.ProductType ToDal(Domain.ProductType entity)
        {
            throw new NotImplementedException();
        }

        protected override Domain.ProductType? ToDomain(EF.ProductType? dalEntity)
        {
            throw new NotImplementedException();
        }
    }
}
