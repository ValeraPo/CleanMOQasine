using Microsoft.AspNetCore.Mvc;
using CleanMOQasine.Business.Models;
using CleanMOQasine.Business.Services;
using AutoMapper;
using CleanMOQasine.API.Configurations;
using CleanMOQasine.API.Models;

namespace CleanMOQasine.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly Mapper _autoMapperInstance;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
            _autoMapperInstance = OrderMapper.GetInstance();
        }

        //api/Orders
        [HttpGet]
        public ActionResult<List<OrderOutputModel>> GetOrders()
        {
            var models = _orderService.GetAllOrders();
            var outputs = _autoMapperInstance.Map<List<OrderOutputModel>>(models);
            return Ok(outputs);
        }

        //api/Orders/42
        [HttpGet("{id}")]
        public ActionResult<OrderOutputModel> GetOrderById(int id)
        {
            var model = _orderService.GetOrderById(id);
            var output = _autoMapperInstance.Map<OrderOutputModel>(model);
            return Ok(output);
        }

        //api/Orders
        [HttpPost]
        public ActionResult AddOrder([FromBody]OrderInsertInputModel order)
        {
            var model = _autoMapperInstance.Map<OrderModel>(order);
            _orderService.AddOrder(model);
            return StatusCode(StatusCodes.Status201Created);
        }

        //api/Orders/42
        [HttpPut("{id}")]
        public ActionResult UpdateOrder(int id, [FromBody] OrderUpdateInputModel order)
        {
            var model = _autoMapperInstance.Map<OrderModel>(order);
            _orderService.UpdateOrder(id, model);
            return Ok($"Order with id = {id} was updated");
        }

        //api/Orders/42/cleaner
        [HttpPut("{id}/cleaner")]
        public ActionResult AddCleaner(int id, [FromBody] OrderCleanerInputModel cleaner)
        {
            var model = _autoMapperInstance.Map<OrderModel>(cleaner);
            _orderService.AddCleaner(id, cleaner.CleanerId);
            return Ok($"Cleaner with id = {cleaner.CleanerId} was added");
        }

        //api/Orders/42/remove-cleaner
        [HttpPut("{id}/remove-cleaner")]
        public ActionResult RemoveCleaner(int id, [FromBody] OrderCleanerInputModel cleaner)
        {
            var model = _autoMapperInstance.Map<OrderModel>(cleaner);
            _orderService.RemoveCleaner(id, cleaner.CleanerId);
            return Ok($"Cleaner with id = {cleaner.CleanerId} was removed");
        }

        //api/Orders/42
        [HttpDelete("{id}")]
        public ActionResult DeleteOrder(int id)
        {
            _orderService.DeleteOrder(id);
            return Ok($"Order with id = {id} was deleted");
        }

        //api/Orders/42
        [HttpPatch("{id}")]
        public ActionResult RestoreOrder(int id)
        {
            _orderService.RestoreOrder(id);
            return Ok($"Order with id = {id} was restored");
        }
    }
}
