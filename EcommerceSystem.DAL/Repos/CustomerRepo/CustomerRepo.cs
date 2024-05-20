using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceSystem.DAL
{
    public class CustomerRepo : ICustomerRepo
    {
        private readonly ApplicationDBContext _context;

        public CustomerRepo(ApplicationDBContext context)
        {
            _context = context;
        }
        public void Add(Customer customer)
        {
            _context.Add(customer);
        }

        public void Delete(int id)
        {
            Customer customer = _context.Customers.Find(id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
            }
        }

        public IEnumerable<Customer> GetAll()
        {
            return _context.Customers.Include(c=>c.Orders);
        }

        public Customer GetById(int id)
        {
            return _context.Customers.Include(c => c.Orders).FirstOrDefault(c => c.Id == id);
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public void Update(Customer customer)
        {
            _context.Update(customer);
        }
    }
}
