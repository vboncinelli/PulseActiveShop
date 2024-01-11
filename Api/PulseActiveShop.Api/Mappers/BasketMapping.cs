using ApiEntities = PulseActiveShop.Api.Entities;
using Domain = PulseActiveShop.Core.Entities;

namespace PulseActiveShop.Api.Mappers
{
    public static class BasketMapping
    {
        public static ApiEntities.Basket? ToApi(this Domain.Basket basket)
        {
            if (basket == null) return null;

            return new ApiEntities.Basket()
            {
                Id = basket.Id,
                CustomerId = basket.CustomerId,
                Items = basket.Items.ToApi()
            };
        }

        public static ApiEntities.BasketItem? ToApi(this Domain.BasketItem basketItem)
        {
            if (basketItem == null) return null;

            return new ApiEntities.BasketItem()
            {
                Id = basketItem.Id,
                BasketId = basketItem.BasketId,
                Product = basketItem.Product.ToApi(),
                Quantity = basketItem.Quantity,
                UnitPrice = basketItem.UnitPrice
            };
        }

        public static List<ApiEntities.BasketItem> ToApi(this IEnumerable<Domain.BasketItem> collection)
        {
            var items = new List<ApiEntities.BasketItem>();
            foreach (var item in collection)
                items.Add(item.ToApi()!);

            return items;
        }
    }
}
