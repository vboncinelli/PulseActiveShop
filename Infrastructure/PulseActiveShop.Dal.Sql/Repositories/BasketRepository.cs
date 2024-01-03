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
