using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceSystem.DAL
{
    public class OrderRepo : IOrderRepo
    {
        private readonly ApplicationDBContext _context;

        public OrderRepo(ApplicationDBContext context)
        {
            _context = context;
        }
        public void Add(Order item)
        {
            _context.Orders.Add(item);
        }

        public void Delete(int id)
        {
            var order= GetById(id);
            _context.Orders.Remove(order);
        }

        public IEnumerable<Order> GetAll()
        {
            return _context.Orders.Include(o=>o.OrderItems);
        }

        public Order GetById(int id)
        {
            return _context.Orders.Include(o => o.OrderItems).FirstOrDefault(o=>o.Id==id);
        }

        public int SaveChanges()
        {
           return _context.SaveChanges();
        }

        public void Update(Order item)
        {
            _context.Update(item);
        }
    }
}
