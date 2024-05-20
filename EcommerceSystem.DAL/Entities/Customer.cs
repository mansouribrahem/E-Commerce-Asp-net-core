using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace EcommerceSystem.DAL
{
    [Index(nameof(UserName), IsUnique = true)]
    public class Customer
    {
        public int Id { get; set; }
        public string UserName { get; set; }= string.Empty;
        public string FirstName { get; set; }= string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty; 

        public ICollection<Order>Orders { get; set; }=new HashSet<Order>();

    }
}
