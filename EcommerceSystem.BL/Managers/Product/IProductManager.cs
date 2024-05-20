using EcommerceSystem.BL;
using EcommerceSystem.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceSystem.BL
{
    public interface IProductManager
    {
        public IEnumerable<GetProductDto> GetAll();
        public GetProductDto GetById(int id);
        public Product Add(AddProductDto item);
        public Product Update(int id,UpdateProductDto item);
        public void Delete(int id);
        
    }
}
