using Microsoft.Extensions.Configuration;
using PulseActiveShop.Core.Interfaces.Repository;
using Domain = PulseActiveShop.Core.Entities;
using EF = PulseActiveShop.Dal.Sql.Entities;

namespace PulseActiveShop.Dal.Sql.Repositories
{
    public class BasketRepository : BaseRepository<Domain.Basket, Domain.BasketCollection, EF.Basket>, IBasketRepository
    {
        public BasketRepository(IConfiguration configuration) : base(configuration, new[] { "Items" })
        {
        }

        protected override IQueryable<EF.Basket> GetDefaultOrdering(IQueryable<EF.Basket> query)
        {
            throw new NotImplementedException();
        }
    }
}
