using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceSystem.DAL
{
    public class OrderItemRepo : IOrderItemRepo
    {
        private readonly ApplicationDBContext _context;
        public OrderItemRepo(ApplicationDBContext context)
        {
            _context=context;
        }

        public ApplicationDBContext Context { get; }

        public void Add(OrderItem item)
        {
            _context.OrderItems.Add(item);
            
        }

        public void Delete(int id)
        {
            OrderItem orderItem=GetById(id);
            _context.OrderItems.Remove(orderItem);
        }

        public IEnumerable<OrderItem> GetAll()
        {
            return _context.OrderItems.Include(i=>i.Product);
        }

        public OrderItem GetById(int id)
        {
            return _context.OrderItems.Include(i => i.Product).FirstOrDefault(i=>i.Id==id);
            
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public void Update(OrderItem item)
        {
            _context.Update(item);
        }
    }
}
