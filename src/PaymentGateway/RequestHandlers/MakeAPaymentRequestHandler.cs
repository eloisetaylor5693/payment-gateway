using MediatR;
using PaymentGateway.Requests;
using PaymentGateway.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PaymentGateway.RequestHandlers
{
    public sealed class MakeAPaymentRequestHandler : IRequestHandler<MakeAPaymentRequest, PaymentResponse>
    {
        public Task<PaymentResponse> Handle(MakeAPaymentRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new PaymentResponse
            {
                TransactionSucessful = true,
                TransationId = request.TransationId,
                Message = "Payment received"
            });
        }
    }
}
