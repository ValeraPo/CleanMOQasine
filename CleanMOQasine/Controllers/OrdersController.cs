using AutoMapper;
using CleanMOQasine.API.Attributes;
using CleanMOQasine.API.Models;
using CleanMOQasine.Business.Models;
using CleanMOQasine.Business.Services;
using CleanMOQasine.Data.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Security.Claims;

namespace CleanMOQasine.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [SwaggerTag("The controller is used to interact with orders")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IUserService _userService;
        private readonly ICleaningAdditionService _cleaningAdditionService;
        private readonly ICleaningTypeService _cleaningTypeService;
        private readonly IRoomService _roomService;
        private readonly IMapper _mapper;

        public OrdersController(IOrderService orderService,
            IUserService userService,
            IMapper mapper,
            ICleaningAdditionService cleaningAdditionService,
            ICleaningTypeService cleaningTypeService,
            IRoomService roomService)
        {
            _orderService = orderService;
            _userService = userService;
            _mapper = mapper;
            _cleaningAdditionService = cleaningAdditionService;
            _cleaningTypeService = cleaningTypeService;
            _roomService = roomService;
        }

        //api/Orders/admin
        [HttpGet]
        [Authorize]
        [ProducesResponseType(typeof(List<OrderOutputModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation("Get all orders by role. Roles: All.")]
        public ActionResult<List<OrderOutputModel>> GetOrders()
        {
            var models = new List<OrderModel>();
            if (GetUserRole() == 1)
                models = _orderService.GetAllOrders();
            else if (GetUserRole() == 2)
                models = _orderService.GetOrdersByClientId(GetUserId());
            else
               models = _orderService.GetOrdersByCleanerId(GetUserId());
            var outputs = _mapper.Map<List<OrderOutputModel>>(models);
            return Ok(outputs);
        }

        //api/Orders/42
        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(typeof(OrderOutputModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation("Get order by id. Roles: All.")]
        public ActionResult<OrderOutputModel> GetOrderById(int id)
        {
            var model = _orderService.GetOrderById(id);
            var output = _mapper.Map<OrderOutputModel>(model);
            return Ok(output);
        }

        //api/Orders
        [HttpPost]
        [AuthorizeEnum(Role.Client)]
        [ProducesResponseType(typeof(OrderOutputModel), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(OrderOutputModel), StatusCodes.Status302Found)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation("Add order. Roles: Client.")]
        public ActionResult AddOrder([FromBody] OrderUpdateInputModel order)
        {
            var modelOrder = CreateOrder(order);
            modelOrder.Client = _userService.GetUserById(GetUserId());
            var createdModelOrder = _orderService.AddOrder(modelOrder);
            // Если не нашли необходимое количество клинеров
            if(createdModelOrder == null)
                return StatusCode(StatusCodes.Status404NotFound);
            // Если нашли клинеров только на другие даты
            if(createdModelOrder.Date != modelOrder.Date)
                return StatusCode(StatusCodes.Status302Found, createdModelOrder);
            return StatusCode(StatusCodes.Status201Created, createdModelOrder);
        }

        //api/Orders/admin
        [HttpPost("admin")]
        [AuthorizeEnum(Role.Admin)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation("Add order. Roles: Admin.")]
        public ActionResult AddOrder([FromBody] OrderInsertInputModel order)
        {
            var modelOrder = CreateOrder(order);
            modelOrder.Client = _userService.GetUserById(order.ClientId);
            _orderService.AddOrder(modelOrder);
            return StatusCode(StatusCodes.Status201Created);
        }

        //api/Orders/42
        [HttpPut("{id}")]
        [AuthorizeEnum(Role.Admin, Role.Client)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation("Update order. Roles: Admin, Client.")]
        public ActionResult UpdateOrder(int id, [FromBody] OrderUpdateInputModel order)
        {
            var model = _mapper.Map<OrderModel>(order);
            _orderService.UpdateOrder(id, model);
            return Ok($"Order with id = {id} was updated");
        }

        //api/Orders/42/cleaner
        [HttpPut("{id}/cleaner")]
        [AuthorizeEnum(Role.Admin)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation("Add cleaner to order. Roles: Admin.")]
        public ActionResult AddCleaner(int id, [FromBody] OrderCleanerInputModel cleaner)
        {
            _orderService.AddCleaner(id, cleaner.CleanerId);
            return Ok($"Cleaner with id = {cleaner.CleanerId} was added");
        }

        //api/Orders/42/remove-cleaner
        [HttpPut("{id}/remove-cleaner")]
        [AuthorizeEnum(Role.Admin)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation("Remove cleaner from order. Roles: Admin.")]
        public ActionResult RemoveCleaner(int id, [FromBody] OrderCleanerInputModel cleaner)
        {
            _orderService.RemoveCleaner(id, cleaner.CleanerId);
            return Ok($"Cleaner with id = {cleaner.CleanerId} was removed");
        }

        //api/Orders/42
        [AuthorizeEnum(Role.Admin)]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation("Delete order. Roles: Admin.")]
        public ActionResult DeleteOrder(int id)
        {
            _orderService.DeleteOrder(id);
            return Ok($"Order with id = {id} was deleted");
        }

        //api/Orders/42
        [AuthorizeEnum(Role.Admin)]
        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation("Restore order. Roles: Admin.")]
        public ActionResult RestoreOrder(int id)
        {
            _orderService.RestoreOrder(id);
            return Ok($"Order with id = {id} was restored");
        }
        
        //api/Orders/42/payment
        [AuthorizeEnum(Role.Admin)]
        [HttpPost("{orderId}/payment")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation("Add payment to order. Roles: Admin.")]
        public ActionResult AddPayment([FromBody] PaymentInputModel payment, int orderId)
        {
            var paymentModel = _mapper.Map<PaymentModel>(payment);
            _orderService.AddPayment(paymentModel, orderId);
            return StatusCode(StatusCodes.Status201Created, payment);
        }

        private int GetUserId()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            List<Claim> claims = identity.Claims.ToList();
            var idUser = int.Parse(claims.Where(c => c.Type == ClaimTypes.UserData).Select(c => c.Value).SingleOrDefault());
            return idUser;
        }

        private int GetUserRole()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            List<Claim> claims = identity.Claims.ToList();
            var role = int.Parse(claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value).SingleOrDefault());
            return role;
        }

        private OrderModel CreateOrder(OrderUpdateInputModel order)
        {
            var modelOrder = _mapper.Map<OrderModel>(order);
            foreach (var c in order.CleaningAdditionIds)
                modelOrder.CleaningAdditions.Add(_cleaningAdditionService.GetCleaningAdditionById(c));
            modelOrder.CleaningType = _cleaningTypeService.GetCleaningTypeById(order.CleaningTypeId);
            foreach (var r in order.RoomIds)
                modelOrder.Rooms.Add(_roomService.GetRoomById(r));

            return modelOrder;
        }
    }
}
