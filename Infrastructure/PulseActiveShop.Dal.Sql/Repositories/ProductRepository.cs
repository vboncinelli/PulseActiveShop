using Microsoft.Extensions.Configuration;
using PulseActiveShop.Dal.Sql.Entities;
using Domain = PulseActiveShop.Core.Entities;
using EF = PulseActiveShop.Dal.Sql.Entities;

namespace PulseActiveShop.Dal.Sql.Repositories
{
    public class ProductRepository : BaseRepository<Domain.Product, Domain.ProductCollection, EF.Product>
    {
        public ProductRepository(IConfiguration configuration, string[]? includedEntities = null) : base(configuration, includedEntities)
        {
        }

        protected override IQueryable<Product> GetDefaultOrdering(IQueryable<Product> query)
        {
            return query.OrderBy(product => product.Id);
        }
    }
}
