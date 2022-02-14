using AutoMapper;
using CleanMOQasine.API.Models;
using CleanMOQasine.Business.Models;
using CleanMOQasine.Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace CleanMOQasine.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentsController : Controller
    {
        private readonly IOrderService _orderService;
        private IMapper _mapper;

        public PaymentsController(IOrderService paymentService, IMapper mapper)
        {
            _orderService = paymentService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public ActionResult<PaymentModel> GetPaymentById(int id)
        {
            var payment = _orderService.GetPaymentById(id);
            return Ok((payment));
        }

        [HttpGet]
        public ActionResult<List<PaymentModel>> GetAllPayments()
        {
            return Ok(_mapper
                .Map<List<PaymentModel>>(_orderService.GetAllPayments()));
        }

        [HttpDelete]
        public ActionResult DeletePaymentById(int id)
        {
            _orderService.DeletePayment(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public ActionResult UpdatePayment([FromBody] PaymentOutputModel payment)
        {
            var paymentModelToUpdate = _mapper.Map<PaymentModel>(payment);
            _orderService.UpdatePayment(paymentModelToUpdate);
            return Ok();
        }
    }
}
