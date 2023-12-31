using Microsoft.Extensions.Configuration;
using PulseActiveShop.Core.Interfaces.Repository;
using PulseActiveShop.Dal.Sql.Entities;
using Domain = PulseActiveShop.Core.Entities;
using EF = PulseActiveShop.Dal.Sql.Entities;

namespace PulseActiveShop.Dal.Sql.Repositories
{
    public class OrderRepository : BaseRepository<Domain.Order, Domain.OrderCollection, EF.Order>, IOrderRepository
    {
        public OrderRepository(IConfiguration configuration) : base(configuration, new[] { "User" })
        {
        }

        protected override IQueryable<Order> GetDefaultOrdering(IQueryable<Order> query)
        {
            throw new NotImplementedException();
        }
    }
}
