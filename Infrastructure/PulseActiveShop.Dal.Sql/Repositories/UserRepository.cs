using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PulseActiveShop.Core.Exceptions;
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

                    return this.ToDomain(user);
                }
            }
            catch (Exception ex)
            {
                throw new DataAccessException("An error occurred while retrieving info about an user", ex);
            }
        }

        public async Task<Domain.User?> FindUserByEmailAsync(string email)
        {
            try
            {
                using (var context = this.GetContext())
                {
                    var user = await context.Set<EF.User>().FirstOrDefaultAsync(e => e.Email == email);

                    return this.ToDomain(user);
                }
            }
            catch (Exception ex)
            {
                throw new DataAccessException("An error occurred while retrieving info about an user", ex);
            }
        }

        protected override IQueryable<EF.User> GetDefaultOrdering(IQueryable<EF.User> query)
        {
            return query.OrderBy(e => e.Username);
        }

        #region Mappings

        protected override Domain.User? ToDomain(EF.User? dalUser)
        {
            if (dalUser == null) return null;

            var user = new Domain.User(dalUser.Username, dalUser.Password, dalUser.Email)
            {
                Id = dalUser.Id,
            };

            return user;
        }

        protected override EF.User ToDal(Domain.User user)
        {
            var dalUser = new EF.User()
            {
                Id = user.Id,
                Email = user.Email,
                Password = user.Password,
                Username = user.Username
            };

            return dalUser;
        } 
        #endregion
    }
}
