using AutoMapper;
using CleanMOQasine.API.Models;
using CleanMOQasine.Business.Models;
using CleanMOQasine.Business.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CleanMOQasine.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IUserService _userService;
        private readonly ICleaningAdditionService _cleaningAdditionService;
        private readonly ICleaningTypeService _cleaningTypeService;
       // private readonly IRoomService _roomService;
        private readonly IMapper _mapper;

        public OrdersController(IOrderService orderService,
            IUserService userService,
            IMapper maper,
            ICleaningAdditionService cleaningAdditionService,
            ICleaningTypeService cleaningTypeService)
           // IRoomService roomService)
        {
            _orderService = orderService;
            _userService = userService;
            _mapper = maper;
            _cleaningAdditionService = cleaningAdditionService;
            _cleaningTypeService = cleaningTypeService;
           // _roomService = roomService;
        }

        //api/Orders
        [HttpGet]
        public ActionResult<List<OrderOutputModel>> GetOrders()
        {
            var models = _orderService.GetAllOrders();
            var outputs = _mapper.Map<List<OrderOutputModel>>(models);
            return Ok(outputs);
        }

        //api/Orders/42
        [HttpGet("{id}")]
        public ActionResult<OrderOutputModel> GetOrderById(int id)
        {
            var model = _orderService.GetOrderById(id);
            var output = _mapper.Map<OrderOutputModel>(model);
            return Ok(output);
        }

        //api/Orders
        [HttpPost]
        public ActionResult AddOrder([FromBody] OrderInsertInputModel order)
        {
            var modelOrder = _mapper.Map<OrderModel>(order);
            foreach(var c in order.CleaningAdditionIds)
                modelOrder.CleaningAdditions.Add(_cleaningAdditionService.GetCleaningAdditionById(c));
            modelOrder.CleaningType = _cleaningTypeService.GetCleaningTypeById(order.CleaningTypeId);
            //foreach (var r in order.RoomIds)
            //    modelOrder.Rooms.Add(_roomService.GetRoomById(r));
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            List<Claim> claims = identity.Claims.ToList();
            var idUser = int.Parse(claims.Where(c => c.Type == ClaimTypes.UserData).Select(c => c.Value).SingleOrDefault());
            modelOrder.Client = _userService.GetUserById(idUser);

            _orderService.AddOrder(modelOrder);
            return StatusCode(StatusCodes.Status201Created);
        }

        //api/Orders/42
        [HttpPut("{id}")]
        public ActionResult UpdateOrder(int id, [FromBody] OrderUpdateInputModel order)
        {
            var model = _mapper.Map<OrderModel>(order);
            _orderService.UpdateOrder(id, model);
            return Ok($"Order with id = {id} was updated");
        }

        //api/Orders/42/cleaner
        [HttpPut("{id}/cleaner")]
        public ActionResult AddCleaner(int id, [FromBody] OrderCleanerInputModel cleaner)
        {
            var model = _mapper.Map<OrderModel>(cleaner);
            _orderService.AddCleaner(id, cleaner.CleanerId);
            return Ok($"Cleaner with id = {cleaner.CleanerId} was added");
        }

        //api/Orders/42/remove-cleaner
        [HttpPut("{id}/remove-cleaner")]
        public ActionResult RemoveCleaner(int id, [FromBody] OrderCleanerInputModel cleaner)
        {
            var model = _mapper.Map<OrderModel>(cleaner);
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

        [HttpPost("{orderId}/payment")]
        public ActionResult AddPayment([FromBody] PaymentInputModel payment, int orderId)
        {
            var paymentModel = _mapper.Map<PaymentModel>(payment);
            _orderService.AddPayment(paymentModel, orderId);
            return StatusCode(StatusCodes.Status201Created, payment);
        }
    }
}
