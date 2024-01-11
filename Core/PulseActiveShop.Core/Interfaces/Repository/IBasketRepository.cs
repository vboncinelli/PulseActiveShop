using PulseActiveShop.Core.Entities;

namespace PulseActiveShop.Core.Interfaces.Repository
{
    public interface IBasketRepository : IRepository<Basket, BasketCollection>
    {
        Task<Basket?> FindBasketByUserIdAsync(Guid userId);

        Task<Basket?> FindBasketByUsernameAsync(string username);
    }
}
