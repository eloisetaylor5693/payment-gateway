using MediatR;
using PaymentGateway.Commands;
using PaymentGateway.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PaymentGateway.Handlers
{
    public sealed class MakeAPaymentHandler : IRequestHandler<MakeAPaymentCommand, PaymentResponse>
    {
        public Task<PaymentResponse> Handle(MakeAPaymentCommand request, CancellationToken cancellationToken)
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
