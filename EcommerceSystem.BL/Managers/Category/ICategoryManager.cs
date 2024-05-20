using EcommerceSystem.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceSystem.BL
{
    public interface ICategoryManager
    {
        public IEnumerable<GetCategoryDto> GetAll();
        public GetCategoryDto GetById(int id);
        public Category Add(AddCategoryDto item);
        public Category Update(int id, UpdateCategoryDto item);
        public void Delete(int id);
    }
}
