using EcommerceSystem.DAL;

namespace EcommerceSystem.BL
{
    public class GetCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public ICollection<GetCategoryProductDto> Products { get; set; } = new HashSet<GetCategoryProductDto>();
    }
}