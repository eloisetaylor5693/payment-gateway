using MediatR;
using Microsoft.AspNetCore.Mvc;
using PaymentGateway.Requests;
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
        public async System.Threading.Tasks.Task<ActionResult<PaymentResponse>> MakePaymentAsync([FromBody] MakeAPaymentRequest request)
        {
            var response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpPost]
        [Route("get-transaction")]
        public async System.Threading.Tasks.Task<ActionResult> GetPaymentInformationAsync([FromBody] GetTransactionRequest request)
        {
            var response = await _mediator.Send(request);

            return Ok(response);
        }
    }
}
