using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PulseActiveShop.Core.Exceptions;
using PulseActiveShop.Dal.Sql.Mappers;
using Domain = PulseActiveShop.Core.Entities;
using EF = PulseActiveShop.Dal.Sql.Entities;

namespace PulseActiveShop.Dal.Sql.Repositories
{
    public class UserRepository : BaseRepository<Domain.User, Domain.UserCollection, EF.User>
    {
        public UserRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<Domain.User?> FindUserByNameAsync(string username)
        {
            try
            {
                using (var context = this.GetContext())
                {
                    var user = await context.Set<EF.User>().FirstOrDefaultAsync(e => e.Username == username);

                    return user?.ToCore<Domain.User, EF.User>();
                }
            }
            catch (Exception ex)
            {
                throw new DataAccessException("An error occurred while retrieving info about an user");
            }
        }

        public async Task<Domain.User?> FindUserByEmailAsync(string email)
        {
            try
            {
                using (var context = this.GetContext())
                {
                    var user = await context.Set<EF.User>().FirstOrDefaultAsync(e => e.Email == email);

                    return user?.ToCore<Domain.User, EF.User>();
                }
            }
            catch (Exception ex)
            {
                throw new DataAccessException("An error occurred while retrieving info about an user");
            }
        }

        protected override IQueryable<EF.User> GetDefaultOrdering(IQueryable<EF.User> query)
        {
            throw new NotImplementedException();
        }
    }
}
