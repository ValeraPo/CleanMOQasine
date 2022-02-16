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
        public ActionResult<List<PaymentInputModel>> GetAllPayments()
        {
            return Ok(_mapper
                .Map<List<PaymentInputModel>>(_paymentService.GetAllPayments()));
        }

        [HttpDelete]
        public ActionResult DeletePaymentById(int id)
        {
            _paymentService.DeletePayment(id);
            return NoContent();
        }

        [HttpPut]
        public ActionResult UpdatePayment([FromBody] PaymentOutputModel payment)
        {
            var paymentModelToUpdate = _mapper.Map<PaymentModel>(payment);
            _paymentService.UpdatePayment(paymentModelToUpdate);
            return Ok();
        }
    }
}
