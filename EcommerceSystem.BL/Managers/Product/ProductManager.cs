using EcommerceSystem.BL;
using EcommerceSystem.DAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace EcommerceSystem.BL
{
    public class ProductManager : IProductManager
    {
        private readonly IProductRepo _productRepo;

        public ProductManager(IProductRepo productRepo)
        {
            _productRepo = productRepo;
        }
        public Product Add(AddProductDto addProductDto)
        {
            Product product=new Product();

            product.Name= addProductDto.Name;
            product.Description= addProductDto.Description;
            product.Price   = addProductDto.Price;
            product.Image= addProductDto.Image;
            product.CategoryId = addProductDto.CategoryId;
            product.Stock= addProductDto.Stock;

            _productRepo.Add(product);
            _productRepo.SaveChanges();
            return product;
        }

        public void Delete(int id)
        {
            
           _productRepo.Delete(id);
           _productRepo.SaveChanges();
        }

        public IEnumerable<GetProductDto> GetAll()
        {
            IEnumerable<GetProductDto> productsDto=_productRepo.GetAll()
                .Select(p => new GetProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    Image = p.Image,
                    CategoryName = p.Category?.Name ?? "NA",
                    Stock = p.Stock,
                }
            );  
            return productsDto;
        }

        public GetProductDto GetById(int id)
        {
            Product product=_productRepo.GetById(id);
            if (product is null)
            {
                return null;
            }

            GetProductDto productDto= new GetProductDto
            {
                Id = product.Id,
                Name= product.Name,
                Description= product.Description,
                Price = product.Price,
                Image = product.Image,
                CategoryName= product.Category?.Name ??"NA",
                Stock = product.Stock,
            };
            

            return productDto;
        }

        public Product Update(int id,UpdateProductDto productDto)
        {
            Product product = _productRepo.GetById(id);
            if (product !=null)
            {
                product.Name = productDto.Name;
                product.Description = productDto.Description;
                product.Price = productDto.Price;
                product.Image = productDto.Image;
                product.CategoryId = productDto.CategoryId;
                product.Stock = productDto.Stock;
                _productRepo.Update(product);
                _productRepo.SaveChanges();
                return product;
            }
            return null;

           
        }

       
    }
}
