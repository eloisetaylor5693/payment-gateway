using Microsoft.AspNetCore.Mvc;
using PaymentGateway.Models;
using System;

namespace PaymentGateway.WebApi.Controllers
{
    [ApiController]
    [Route("payment-gateway/api/pay")]
    public class PaymentController : ControllerBase
    {
        [HttpPost]
        public ActionResult MakePayment([FromBody] PaymentRequest request)
        {
            return Ok("Payment received");
        }

        [HttpGet]
        [Route("get-transaction")]
        public ActionResult GetPaymentInformation([FromQuery] string paymentId)
        {
            return Ok("Here's your payment information");
        }
    }
}
