using EcommerceSystem.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceSystem.DAL
{
    public interface IRepo<T>
    {
        public IEnumerable<T> GetAll();
        public T GetById(int id);
        public void Add(T item);
        public void Update(T item);
        public void Delete(int id);
        public int SaveChanges();
    }
}
