using EcommerceSystem.BL;
using EcommerceSystem.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class ProductController : ControllerBase
    {
        private readonly IProductManager _productManager;

        public ProductController(IProductManager productManager)
        {
            _productManager = productManager;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable<GetProductDto> products = _productManager.GetAll();
            if (products is null)
            {
                return NotFound();
            }
            return Ok(products);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Add(AddProductDto productDto)
        {
            Product product =_productManager.Add(productDto);
            if (product == null) { return BadRequest("Faild to add product!"); }
            return CreatedAtAction(nameof(GetById), new { id = product.Id }, productDto);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            GetProductDto productDto = _productManager.GetById(id);
            if (productDto is null)
            {
                return NotFound();
            }
            return Ok(productDto);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            GetProductDto productDto = _productManager.GetById(id);
            if (productDto is null)
            {
                return NotFound();
            }
            _productManager.Delete(id);
            return NoContent();
        }
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Update(int id,UpdateProductDto productDto)
        {
            var product=_productManager.Update(id, productDto);
            if (product is null)
            {
                return NotFound();
            }
            return Ok("Updated Successfully");
        }



    }
}
