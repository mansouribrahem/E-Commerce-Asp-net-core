using EcommerceSystem.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceSystem.BL
{
    public interface ICustomerManager
    {
        public IEnumerable<GetCustomerDto> GetAll();
        public GetCustomerDto GetById(int id);
        public Customer Add(AddCustomerDto item);
        public Customer Update(int id, AddCustomerDto item);
        public void Delete(int id);
    }
}
