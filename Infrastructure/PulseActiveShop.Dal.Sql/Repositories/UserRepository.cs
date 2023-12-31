using Microsoft.Extensions.Configuration;
using Domain = PulseActiveShop.Core.Entities;
using EF = PulseActiveShop.Dal.Sql.Entities;

namespace PulseActiveShop.Dal.Sql.Repositories
{
    public class UserRepository : BaseRepository<Domain.User, Domain.UserCollection, EF.User>
    {
        public UserRepository(IConfiguration configuration) : base(configuration)
        {
        }

        protected override IQueryable<EF.User> GetDefaultOrdering(IQueryable<EF.User> query)
        {
            throw new NotImplementedException();
        }
    }
}
