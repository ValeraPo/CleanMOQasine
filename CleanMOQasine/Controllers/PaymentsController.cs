using AutoMapper;
using CleanMOQasine.Business.Models;
using CleanMOQasine.Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace CleanMOQasine.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentsController : Controller
    {
        private readonly IPaymentService _paymentService;
        private IMapper _mapper;

        public PaymentsController(IPaymentService paymentService, IMapper mapper)
        {
            _paymentService = paymentService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public ActionResult<PaymentModel> GetPaymentById(int id)
        {
            var payment = _paymentService.GetPaymentById(id);
            return Ok((payment));
        }

        [HttpGet]
        public ActionResult<List<PaymentModel>> GetAllPayments()
        {
            return Ok(_mapper
                .Map<List<PaymentModel>>(_paymentService.GetAllPayments()));
        }

        [HttpDelete]
        public ActionResult DeletePaymentById(int id)
        {
            _paymentService.DeletePayment(id);
            return NoContent();
        }

        [HttpPost]
        public ActionResult AddPayment([FromBody] PaymentModel payment, [FromQuery]int orderId)
        {
            _paymentService.AddPayment(payment, orderId);
            return StatusCode(StatusCodes.Status201Created, payment);
        }

        [HttpPut("{id}")]
        public ActionResult UpdatePayment([FromBody] PaymentModel payment, int id)
        {
            _paymentService.UpdatePayment(payment, id);
            return Ok();
        }
    }
}
