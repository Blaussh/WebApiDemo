using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiDemo.Models
{
    public class Repository : IRepository
    {
        private WebApiDemoContext _context = null;

        public Repository(WebApiDemoContext context)
        {
            _context = context;
        }

        public IQueryable<Order> GetAllOrders()
        {
            return _context.Orders;
        }

        public IQueryable<Order> GetAllOrdersWithDetails()
        {
            return _context.Orders.AsQueryable().Include(o => o.OrderDetails);
        }

        public Order GetOrder(int id)
        {
            return _context.Orders.AsQueryable().FirstOrDefault(o => o.Id == id);
        }
    }
}
