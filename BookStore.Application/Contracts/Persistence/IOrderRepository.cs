using BookStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Application.Contracts.Persistence
{
    public interface IOrderRepository : IAsyncRepository<Order>
    {

    }
}
