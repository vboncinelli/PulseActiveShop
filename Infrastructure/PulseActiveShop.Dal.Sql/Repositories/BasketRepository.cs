using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PulseActiveShop.Core.Exceptions;
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

        public async Task<Domain.Basket?> FindBasketByUserIdAsync(Guid customerId)
        {
            try
            {
                using(var context = this.GetContext())
                {
                    var basket = await context.Set<EF.Basket>().FirstOrDefaultAsync(e => e.CustomerId == customerId);

                    return this.ToDomain(basket);
                }
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ex.Message, ex);
            }
        }

        public async Task<Domain.Basket?> FindBasketByUsernameAsync(string username)
        {
            try
            {
                using (var context = this.GetContext())
                {
                    var dalBasket = await (from basket in context.Set<EF.Basket>()
                                join user in context.Set<EF.User>() on basket.Id equals user.Id
                                where user.Username == username
                                select basket).
                                FirstOrDefaultAsync();

                    return this.ToDomain(dalBasket);
                }
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ex.Message, ex);
            }
        }

        protected override IQueryable<EF.Basket> GetDefaultOrdering(IQueryable<EF.Basket> query)
        {
            return query.OrderBy(e => e.Id);
        }

        #region Mappings 

        protected override EF.Basket ToDal(Domain.Basket entity)
        {
            var basketItems = this.ToDal(entity.Items);

            var dalEntity = new EF.Basket()
            {
                Id = entity.Id,
                CustomerId = entity.CustomerId,
                Items = basketItems
            };

            return dalEntity;
        }

        protected override Domain.Basket? ToDomain(EF.Basket? dalEntity)
        {
            if (dalEntity == null) return null;

            var basket = new Domain.Basket(dalEntity.CustomerId);

            basket.Id = dalEntity.Id;

            foreach (var item in dalEntity.Items)
            {
                basket.AddItem(item.ProductId, item.UnitPrice, item.Quantity);
            }

            return basket;
        }

        protected EF.BasketItem ToDal(Domain.BasketItem item)
        {
            var dalItem = new EF.BasketItem()
            {
                Id = item.Id,
                BasketId = item.BasketId,
                ProductId = item.ProductId,
                Quantity = item.Quantity,
                UnitPrice = item.UnitPrice,
            };

            return dalItem;
        }

        protected Domain.BasketItem? ToDomain(EF.BasketItem item)
        {
            if (item == null)
                return null;

            var domainItem = new Domain.BasketItem(item.ProductId, item.Quantity, item.UnitPrice);

            return domainItem;
        }

        protected List<EF.BasketItem> ToDal(IEnumerable<Domain.BasketItem> collection)
        {
            var items = new List<EF.BasketItem>();

            if (collection != null)
            {
                foreach (var item in collection)
                {
                    items.Add(this.ToDal(item));
                }
            }

            return items;
        }

        protected List<Domain.BasketItem> ToDomain(IEnumerable<EF.BasketItem> collection)
        {
            var items = new List<Domain.BasketItem>();

            if (collection != null)
            {
                foreach (var item in collection)
                {
                    items.Add(this.ToDomain(item)!);
                }
            }

            return items;
        }
    } 
    #endregion
}
