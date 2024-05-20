using EcommerceSystem.BL.DTOs.Order;
using EcommerceSystem.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceSystem.BL
{
    public interface IOrderManager
    {
        public IEnumerable<GetOrderDto> GetAll();
        public GetOrderDto GetById(int id);
        public Order Add(AddOrderDto item);
        public Order Update(int id, AddOrderDto item);
        public void Delete(int id);
    }
}
