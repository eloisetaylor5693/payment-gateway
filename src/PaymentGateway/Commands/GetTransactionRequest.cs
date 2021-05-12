using MediatR;
using System;

namespace PaymentGateway.Commands
{
    public class GetTransactionRequest : IRequest<string>
    {
        public Guid TransationId { get; set; }
    }
}
