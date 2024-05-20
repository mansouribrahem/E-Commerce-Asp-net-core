using EcommerceSystem.BL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EcommerceSystem.DAL;
namespace EcommerceSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderManager _orderManager;

        public OrderController(IOrderManager orderManager)
        {
            _orderManager = orderManager;
        }
        [HttpPost]
        public IActionResult Add(AddOrderDto addOrderDto)
        {
           Order order= _orderManager.Add(addOrderDto);
            if (order != null)
            {
                return Ok($"Total price is ${order.TotalPrice}");
            }
            else
            { return BadRequest(); }

        }
    }
}
