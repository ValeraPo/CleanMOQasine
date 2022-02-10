using CleanMOQasine.Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace CleanMOQasine.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<OrderModel>> GetOrders()
        {
            return Ok(new List<OrderModel> { new OrderModel() });
        }

        [HttpGet("{id}")]
        public ActionResult<OrderModel> GetOrderById(int id)
        {
            return Ok(new OrderModel());
        }

        [HttpPost]
        public ActionResult AddOrder(OrderModel order)
        {
            return StatusCode(StatusCodes.Status201Created, order);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateOrder(int id, OrderModel order)
        {
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteOrder(int id)
        {
            return Accepted();
        }

        [HttpPatch("{id}")]
        public ActionResult RestoreOrder(int id)
        {
            return Accepted();
        }
    }
}
