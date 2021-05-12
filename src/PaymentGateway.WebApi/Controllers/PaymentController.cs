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

        [HttpPost]
        [Route("get-transaction")]
        public async System.Threading.Tasks.Task<ActionResult> GetPaymentInformationAsync([FromBody] GetTransactionCommand request)
        {
            var response = await _mediator.Send(request);

            return Ok(response);
        }
    }
}
