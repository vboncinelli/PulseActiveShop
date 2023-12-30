using PulseActiveShop.Dal.Sql.Entities;
using Domain = PulseActiveShop.Core.Entities;
using EF = PulseActiveShop.Dal.Sql.Entities;

namespace PulseActiveShop.Dal.Sql.Repositories
{
    public class ProductRepository : BaseRepository<Domain.Product, Domain.ProductCollection, EF.Product>
    {

        protected override IQueryable<Product> GetDefaultOrdering(IQueryable<Product> query)
        {
            throw new NotImplementedException();
        }
    }
}
