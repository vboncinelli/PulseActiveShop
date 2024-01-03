using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PulseActiveShop.Core.Entities;
using PulseActiveShop.Core.Exceptions;
using PulseActiveShop.Core.Interfaces.Repository;
using Domain = PulseActiveShop.Core.Entities;
using EF = PulseActiveShop.Dal.Sql.Entities;

namespace PulseActiveShop.Dal.Sql.Repositories
{
    public class OrderRepository : BaseRepository<Domain.Order, Domain.OrderCollection, EF.Order>, IOrderRepository
    {
        public OrderRepository(IConfiguration configuration) : base(configuration, new[] { "OrderItems" })
        {
        }

        public override async Task<Domain.Order> AddAsync(Domain.Order entity)
        {
            try
            {
                using (var context = this.GetContext())
                {
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        var newOrder = await base.AddAsync(entity);

                        foreach (var item in entity.OrderItems)
                        {
                            var attached = context.Set<EF.OrderItem>().Add(this.ToDal(item));
                            attached.State = EntityState.Added;
                        }

                        await context.SaveChangesAsync();

                        transaction.Commit();

                        return newOrder;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ex.Message, ex);
            }
        }

        public async Task<OrderCollection> GetCustomerOrdersAsync(int customerId, int page, int pageSize)
        {
            try
            {
                using (var context = this.GetContext())
                {
                    var query = context.Set<EF.Order>().Where(e => e.CustomerId == customerId);

                    return await base.ExecutePaginatedQueryAsync(query, page, pageSize);
                }
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ex.Message, ex);
            }
        }

        protected override IQueryable<EF.Order> GetDefaultOrdering(IQueryable<EF.Order> query)
        {
            return query.OrderBy(e => e.OrderDate);
        }

        #region Mappings

        protected Domain.OrderItem ToDomain(EF.OrderItem orderItem)
        {
            var itemOrdered = new Domain.ProductOrdered(orderItem.ProductId, orderItem.ProductName, orderItem.PictureUri);

            var dalItem = new Domain.OrderItem(itemOrdered, orderItem.UnitPrice, orderItem.Units);

            return dalItem;
        }

        protected override Domain.Order? ToDomain(EF.Order? dalEntity)
        {
            if (dalEntity == null)
                return null;

            var address = new Domain.Address(
                Street: dalEntity.Street!,
                City: dalEntity.City!,
                StateOrProvince: dalEntity.StateOrProvince!,
                Country: dalEntity.Country!,
                ZipCode: dalEntity.ZipCode!);

            var order = new Domain.Order(dalEntity.CustomerId, address, this.ToDomain(dalEntity.OrderItems));

            return order;
        }

        protected List<Domain.OrderItem> ToDomain(IEnumerable<EF.OrderItem> collection)
        {
            var items = new List<Domain.OrderItem>();

            if (collection != null)
            {
                foreach (var item in collection)
                {
                    items.Add(ToDomain(item));
                }
            }

            return items;
        }

        protected override EF.Order ToDal(Domain.Order order)
        {
            var dalOrder = new EF.Order()
            {
                Id = order.Id,
                CustomerId = order.CustomerId,
                OrderDate = order.OrderDate,
                Street = order.ShipToAddress.Street,
                City = order.ShipToAddress.City,
                StateOrProvince = order.ShipToAddress.StateOrProvince,
                Country = order.ShipToAddress.Country,
                ZipCode = order.ShipToAddress.ZipCode,
                OrderItems = ToDal(order.OrderItems)
            };

            return dalOrder;
        }

        protected EF.OrderItem ToDal(Domain.OrderItem orderItem)
        {
            var dalItem = new EF.OrderItem()
            {
                Id = orderItem.Id,
                ProductId = orderItem.ItemOrdered.ProductId,
                ProductName = orderItem.ItemOrdered.ProductName,
                PictureUri = orderItem.ItemOrdered.PictureUri,
                UnitPrice = orderItem.UnitPrice,
                Units = orderItem.Units
            };

            return dalItem;
        }

        protected List<EF.OrderItem> ToDal(IEnumerable<Domain.OrderItem> collection)
        {
            var items = new List<EF.OrderItem>();

            if (collection != null)
            {
                foreach (var item in collection)
                {
                    items.Add(ToDal(item));
                }
            }

            return items;
        }


        #endregion
    }
}
