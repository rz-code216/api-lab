using Entity;
using System;
using System.Collections.Generic;
using System.Text;
using Entity;
using Microsoft.EntityFrameworkCore;
using Repository;

namespace Repository
{
    public class OrdersRepository :IOrdersRepository
    {
        private readonly storeDBContext _dbContext;

        public OrdersRepository(storeDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Order>> GetAllOrders()
        {
            return await _dbContext.Orders.ToListAsync();
        }

        public async Task<Order> GetOrderById(int id)
        {
            return await _dbContext.Orders.FindAsync(id);
        }
        
        public async Task<Order> AddOrder(Order order)
        {
            _dbContext.Orders.Add(order);
            await _dbContext.SaveChangesAsync();
            return order;
        }
    }
}
