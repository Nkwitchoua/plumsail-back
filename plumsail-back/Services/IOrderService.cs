using plumsail_back.Models;

namespace plumsail_back.Services
{
    public interface IOrderService
    {
        Task<List<Order>> GetOrders();
        Task<Order> SaveOrder(Order order);
        Task<Order> GetOrderById(int id);
        Task<Order> UpdateOrder(Order order);
        Task<bool> DeleteOrder(int id);
    }
}
