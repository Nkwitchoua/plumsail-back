using Microsoft.EntityFrameworkCore;
using plumsail_back.Models;

namespace plumsail_back.Services
{
    public class OrderService : IOrderService
    {
        private readonly AppDbContext _dbOrders;

        public OrderService(AppDbContext context)
        {
            _dbOrders = context;
        }

        public async Task<List<Order>> GetOrders()
        {
            return await _dbOrders.Orders.ToListAsync();
        }

        public async Task<Order> SaveOrder(Order order)
        {
            _dbOrders.Orders.Add(order);
            await _dbOrders.SaveChangesAsync();
            return order;
        }

        public async Task<Order> GetOrderById(int id)
        {
            var order = await _dbOrders.Orders.Where(o => o.Id == id).FirstOrDefaultAsync();

            return order;
        }

        public async Task<Order> UpdateOrder(Order order)
        {
            var existingOrder = await _dbOrders.Orders.FindAsync(order.Id);
            if (existingOrder == null)
            {
                return null;
            }

            _dbOrders.Entry(existingOrder).CurrentValues.SetValues(order);
            await _dbOrders.SaveChangesAsync();

            return order;
        }

        public async Task<bool> DeleteOrder(int id)
        {
            var order = await _dbOrders.Orders.Where(o => o.Id == id).FirstOrDefaultAsync();

            if (order == null)
            {
                return false;
            }

            _dbOrders.Orders.Remove(order);
            await _dbOrders.SaveChangesAsync();

            return true;
        }
    }
}
