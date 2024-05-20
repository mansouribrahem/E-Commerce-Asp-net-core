using EcommerceSystem.BL;
using EcommerceSystem.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceSystem.BL
{
    public class AddOrderDto
    {
        public int CustomerId { get; set; } 
        public List<AddOrderItemDto> OrderItems { get; set; }=new List<AddOrderItemDto>();  

    }
}
