using Microsoft.Extensions.Configuration;
using Domain = PulseActiveShop.Core.Entities;
using EF = PulseActiveShop.Dal.Sql.Entities;

namespace PulseActiveShop.Dal.Sql.Repositories
{
    public class ProductRepository : BaseRepository<Domain.Product, Domain.ProductCollection, EF.Product>
    {
        public ProductRepository(IConfiguration configuration) : base(configuration, new[] { "Brand", "ProductType" })
        {
        }

        protected override IQueryable<EF.Product> GetDefaultOrdering(IQueryable<EF.Product> query)
        {
            return query.OrderBy(product => product.Id);
        }
    }
}
