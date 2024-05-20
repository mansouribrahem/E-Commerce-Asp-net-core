using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceSystem.DAL
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }=string.Empty;
        public decimal TotalPrice { get; set; }
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }=new HashSet<OrderItem>();
    }
}
