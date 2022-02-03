using CleanMOQasine.Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace CleanMOQasine.API.Controllers
{
    public class PaymentsController : Controller
    {
        [HttpGet("{id}")]
        public ActionResult<PaymentModel> GetPaymentById(int id)
        {
            //if () payment is null
                return BadRequest();
            //else
                return Ok();

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
        public ActionResult AddPayment(PaymentModel payment)
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
