using AutoMapper;
using CleanMOQasine.API.Models.Inputs;
using CleanMOQasine.Business.Configurations;
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
        private Mapper _mapper;

        public PaymentsController(IPaymentService paymentService, IAutoMapperFromApi mapper)
        {
            _paymentService = paymentService;
            _mapper = mapper.InitAutoMapperFromApi();
        }

        [HttpGet("{id}")]
        public ActionResult<PaymentModel> GetPaymentById(int id)
        {
            var payment = _paymentService.GetPaymentById(id);
            if (payment is null)
                return BadRequest();
            else
                return Ok(payment);

        }

        [HttpGet]
        public ActionResult<List<PaymentModel>> GetAllPayments()
        {
            return Ok();
        }

        [HttpDelete]
        public ActionResult DeletePaymentById(int id)
        {
            //if () payment is null
            return BadRequest();
            //else
            return Ok();
        }
        [HttpPost]
        public ActionResult AddPayment(PaymentInputModel payment, int orderId)
        {
            return StatusCode(StatusCodes.Status201Created, payment);
        }

        [HttpPut]
        public ActionResult UpdatePayment(PaymentModel payment)
        {
            //if () payment is null
            return BadRequest();
            //else
            return Ok();
        }
    }
}
