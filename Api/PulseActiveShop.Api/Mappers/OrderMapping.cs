using ApiEntities = PulseActiveShop.Api.Entities;
using Domain = PulseActiveShop.Core.Entities;

namespace PulseActiveShop.Api.Mappers
{
    public static class OrderMapping
    {
        public static ApiEntities.Order ToApi(this Domain.Order order)
        {
            return new ApiEntities.Order()
            {
                Id = order.Id,
                CustomerId = order.CustomerId,
                OrderDate = order.OrderDate,
                ShipToAddress = order.ShipToAddress.ToApi(),
                OrderItems = order.OrderItems.ToApi(),
            };
        }

        public static IEnumerable<ApiEntities.Order> ToApi(this IEnumerable<Domain.Order> orders)
        {
            var list = new List<ApiEntities.Order>();

            foreach(var order in orders)
                list.Add(order.ToApi());

            return list;
        }

        public static ApiEntities.OrderItem? ToApi(this Domain.OrderItem item)
        {
            if (item is null) return null;

            return new ApiEntities.OrderItem()
            {
                Id = item.Id,
                UnitPrice = item.UnitPrice,
                Units = item.Units,
                ItemOrdered = item.ItemOrdered.ToApi(),
            };
        }

        public static List<ApiEntities.OrderItem> ToApi(this IEnumerable<Domain.OrderItem> items)
        {
            var list = new List<ApiEntities.OrderItem>();

            foreach (var item in items)
                if (item != null) 
                    list.Add(item.ToApi()!);

            return list;
        }

        public static ApiEntities.ProductOrdered ToApi(this Domain.ProductOrdered productOrdered)
        {
            return new ApiEntities.ProductOrdered()
            {
                ProductId = productOrdered.ProductId,
                PictureUri = productOrdered.PictureUri,
                ProductName = productOrdered.ProductName
            };
        }

        public static ApiEntities.Address ToApi(this Domain.Address address)
        {
            return new ApiEntities.Address()
            {
                City = address.City,
                Country = address.Country,
                StateOrProvince = address.StateOrProvince,
                Street = address.Street,
                ZipCode = address.ZipCode,
            };
        }
    }
}
