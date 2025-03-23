using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using plumsail_back.Models;
using plumsail_back.Services;

namespace plumsail_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("GetOrders")]
        public async Task<IActionResult> GetOrders()
        {
            var orders = await _orderService.GetOrders();

            return Ok(orders);
        }

        [HttpPost("SaveOrder")]
        public async Task<IActionResult> SaveOrder([FromBody] Order order)
        {
            var newOrder = await _orderService.SaveOrder(order);

            return Ok(newOrder);
        }

        [HttpPost("UpdateOrder")]
        public async Task<IActionResult> UpdateOrder([FromBody] Order order)
        {
            var result = await _orderService.UpdateOrder(order);

            if(result == null) return Problem("Could not find order");

            return Ok(result);
        }

        [HttpPost("DeleteOrder")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var result = await _orderService.DeleteOrder(id);

            if(!result) return Problem("Could not find order");

            return Ok();
        }
    }
}
