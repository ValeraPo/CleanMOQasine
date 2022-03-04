using AutoMapper;
using CleanMOQasine.API.Attributes;
using CleanMOQasine.API.Models;
using CleanMOQasine.Business.Models;
using CleanMOQasine.Business.Services;
using CleanMOQasine.Data.Enums;
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
        [AuthorizeEnum(Role.Admin)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public ActionResult<PaymentModel> GetPaymentById(int id)
        {
            var payment = _paymentService.GetPaymentById(id);
            return Ok((payment));
        }

        [HttpGet]
        [AuthorizeEnum(Role.Admin)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public ActionResult<List<PaymentInputModel>> GetAllPayments()
        {
            return Ok(_mapper
                .Map<List<PaymentInputModel>>(_paymentService.GetAllPayments()));
        }

        [HttpDelete]
        [AuthorizeEnum(Role.Admin)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public ActionResult DeletePaymentById(int id)
        {
            _paymentService.DeletePayment(id);
            return NoContent();
        }

        [HttpPut]
        [AuthorizeEnum(Role.Admin)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public ActionResult UpdatePayment([FromBody] PaymentOutputModel payment)
        {
            var paymentModelToUpdate = _mapper.Map<PaymentModel>(payment);
            _paymentService.UpdatePayment(paymentModelToUpdate);
            return Ok();
        }

        [HttpGet("{clientId}")] //иначе ошибка сваггера, да и по логике нужен гет (Т_Т)
        [AuthorizeEnum(Role.Admin)]
        [ProducesResponseType(typeof(GradeBaseOutputModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public ActionResult GetPaymentsByCleanerId(int clientId)
        {
            return Ok(_mapper.Map<List<PaymentOutputModel>>(_paymentService.GetPaymentsByClientId(clientId)));
        }

    }
}
