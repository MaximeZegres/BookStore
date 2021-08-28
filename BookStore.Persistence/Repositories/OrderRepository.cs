using BookStore.Application.Contracts.Persistence;
using BookStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Persistence.Repositories
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(BookStoreDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Order> GetOrderByIdAsync(int id)
        {
            return await _dbContext.Orders.Include(o => o.OrderItems).FirstOrDefaultAsync(i => i.OrderId == id);
        }
    }
}
