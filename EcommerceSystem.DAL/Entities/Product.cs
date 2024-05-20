using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceSystem.DAL
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        [MaxLength(500)]
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Image {  get; set; }= string.Empty;

        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
