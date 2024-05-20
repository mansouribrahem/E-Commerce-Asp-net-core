using EcommerceSystem.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceSystem.BL
{
    public class CustomerManager:ICustomerManager
    {
        private readonly ICustomerRepo _customerRepo;

        public CustomerManager(ICustomerRepo customerRepo)
        {
            _customerRepo = customerRepo;
        }

        public Customer Add(AddCustomerDto item)
        {
            Customer customer = new Customer()
            {
                Address = item.Address,
                FirstName = item.FirstName,
                LastName = item.LastName,   
                Orders = item.Orders,
                UserName = item.UserName
            };
            _customerRepo.Add(customer);
            return customer;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GetCustomerDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public GetCustomerDto GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Customer Update(int id, AddCustomerDto item)
        {
            throw new NotImplementedException();
        }
    }
}
