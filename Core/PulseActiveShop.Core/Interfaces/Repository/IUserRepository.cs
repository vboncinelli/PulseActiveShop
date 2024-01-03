using PulseActiveShop.Core.Entities;

namespace PulseActiveShop.Core.Interfaces.Repository
{
    public interface IUserRepository : IRepository<User, UserCollection>
    {
        Task<User?> FindUserByEmailAsync(string email);

        Task<User?> FindUserByNameAsync(string username);
    }
}
