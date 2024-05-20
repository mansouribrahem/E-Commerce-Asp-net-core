using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceSystem.DAL
{
    public class ProductRepo : IProductRepo
    {
        private readonly ApplicationDBContext _context;

        public ProductRepo(ApplicationDBContext context)
        {
            _context = context;
        }
        public void Add(Product item)
        {
            _context.Products.Add(item);
        }

        public void Delete(int id)
        {
            Product product= _context.Products.Find(id);
            if (product != null)
            {
                _context.Products.Remove(product);
            }
            
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Products.Include(p=>p.Category);
        }

        public Product GetById(int id)
        {

            return _context.Products.Include(p => p.Category).FirstOrDefault(p=>p.Id==id);
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public void Update(Product item)
        {
           _context.Update(item);
        }
    }
}
