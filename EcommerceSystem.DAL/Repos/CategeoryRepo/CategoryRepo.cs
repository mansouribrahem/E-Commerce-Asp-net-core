using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceSystem.DAL
{
    public class CategoryRepo : ICategoryRepo
    {
        private readonly ApplicationDBContext _context;

        public CategoryRepo(ApplicationDBContext context)
        {
            _context = context;
        }
        public void Add(Category category)
        {
            _context.Add(category);
        }

        public void Delete(int id)
        {
            Category category = _context.Categories.Find(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
            }
        }

        public IEnumerable<Category> GetAll()
        {
           return _context.Categories.Include(c=>c.Products);
        }

        public Category GetById(int id)
        {
            return _context.Categories.Include(c=> c.Products).FirstOrDefault(c=> c.Id == id);
        }

        public int SaveChanges()
        {
           return _context.SaveChanges();
        }

        public void Update(Category category)
        {
           _context.Update(category);
        }
    }
}
