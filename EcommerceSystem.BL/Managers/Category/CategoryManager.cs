using EcommerceSystem.DAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EcommerceSystem.BL
{
    public class CategoryManager : ICategoryManager
    {
        private readonly ICategoryRepo _categoryRepo;

        public CategoryManager(ICategoryRepo categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }
        public Category Add(AddCategoryDto categoryDto)
        {
            Category category = new Category
            {
                Name= categoryDto.Name,
                Description= categoryDto.Description,
                
            };
            _categoryRepo.Add(category);
            _categoryRepo.SaveChanges();
            return category;
        }

        public void Delete(int id)
        {
            Category category=_categoryRepo.GetById(id);
            _categoryRepo.Delete(id);
            _categoryRepo.SaveChanges();
        }

        public IEnumerable<GetCategoryDto> GetAll()
        {
            List<GetCategoryDto> categories = new List<GetCategoryDto>();

            foreach (var category in _categoryRepo.GetAll())
            {
                GetCategoryDto cate = new GetCategoryDto();
                cate.Id = category.Id;
                cate.Name= category.Name;
                cate.Description = category.Description;
                ICollection<GetCategoryProductDto> products = new HashSet<GetCategoryProductDto>();

                foreach (var product in category.Products)
                {
                    GetCategoryProductDto productdto = new GetCategoryProductDto
                    {
                        Id= product.Id,
                        Name = product.Name,
                        Description = product.Description,
                        Image = product.Image,
                        Price = product.Price,
                        Stock = product.Stock,
                    };
                    products.Add(productdto);
                }
                cate.Products = products;
                categories.Add(cate);
            }
            return categories;
            
        }

        public GetCategoryDto GetById(int id)
        {

            Category category = _categoryRepo.GetById(id);
            if (category is null)
                return null;
            

            ICollection<GetCategoryProductDto> products = new HashSet<GetCategoryProductDto>();

            foreach (var product in category.Products)
            {
                GetCategoryProductDto productdto = new GetCategoryProductDto
                {
                    Id= product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Image = product.Image,
                    Price = product.Price,
                    Stock = product.Stock,
                };
                products.Add(productdto);
            }


            GetCategoryDto categoryDto = new GetCategoryDto
            {
                Id= category.Id,
                Name = category.Name,
                Description = category.Description,
                Products = products
            };
            return categoryDto;
        }

        public Category Update(int id, UpdateCategoryDto categoryDto)
        {
            Category category=_categoryRepo.GetById(id);
            if (category != null)
            {
                category.Name = categoryDto.Name;
                category.Description= categoryDto.Description;
                _categoryRepo.SaveChanges();
                return category;
            }
            return null;
        }
    }
}
