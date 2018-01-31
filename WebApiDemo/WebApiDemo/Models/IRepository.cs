using System.Linq;

namespace WebApiDemo.Models
{
    public interface IRepository
    {
        IQueryable<Order> GetAllOrders();
        IQueryable<Order> GetAllOrdersWithDetails();
        Order GetOrder(int id);
    }
}