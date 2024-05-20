using EcommerceSystem.DAL;

namespace EcommerceSystem.BL
{
    public class AddProductDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Image { get; set; } = string.Empty;
        public int CategoryId { get; set; }
    }
}