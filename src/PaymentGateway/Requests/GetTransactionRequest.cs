using MediatR;
using System;

namespace PaymentGateway.Requests
{
    public class GetTransactionRequest : IRequest<string>
    {
        public Guid TransationId { get; set; }
    }
}
