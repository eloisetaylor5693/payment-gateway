using MediatR;
using Microsoft.AspNetCore.Mvc;
using PaymentGateway.Commands;
using PaymentGateway.Models;

namespace PaymentGateway.WebApi.Controllers
{
    [ApiController]
    [Route("payment-gateway/api/pay")]
    public class PaymentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PaymentController(IMediator mediator) => _mediator = mediator;

        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult<PaymentResponse>> MakePaymentAsync([FromBody] MakeAPaymentCommand request)
        {
            var response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpGet]
        [Route("get-transaction")]
        public ActionResult GetPaymentInformation([FromQuery] string paymentId)
        {
            return Ok("Here's your payment information");
        }
    }
}
