﻿using PulseActiveShop.Core.Entities;

namespace PulseActiveShop.Core.Interfaces.Repository
{
    public interface IOrderRepository : IRepository<Order, OrderCollection>
    {
        Task<OrderCollection> GetCustomerOrdersAsync(Guid customerId, int page, int pageSize);
    }
}
