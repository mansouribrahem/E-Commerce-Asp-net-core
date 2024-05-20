using EcommerceSystem.BL;
using EcommerceSystem.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EcommerceSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Category]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryManager _categoryManager;

        public CategoryController(ICategoryManager categoryManager)
        {
            _categoryManager = categoryManager;
        }
        [HttpGet]
        public IActionResult GetAll() 
        {
            var categories= _categoryManager.GetAll();
            return Ok(categories);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var category= _categoryManager.GetById(id);
            if (category==null)
                return NotFound();
           
            return Ok(category);
        }
        [HttpPost]
        public IActionResult Add(AddCategoryDto categoryDto)
        {
            Category category=_categoryManager.Add(categoryDto);

            return Ok( new { id=category.Id,name=category.Name } );
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            GetCategoryDto category=_categoryManager.GetById(id);
            if(category==null)
                return NotFound();
            _categoryManager.Delete(id);
            return Ok();
        }
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Update(int id,UpdateCategoryDto categoryDto)
        {
            Category category= _categoryManager.Update(id,categoryDto);
            if(category == null)
                return NotFound();  
            return Ok(new { id = category.Id, name = category.Name, description=category.Description});
        }
    }
}
