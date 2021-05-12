using MediatR;
using System;

namespace PaymentGateway.Commands
{
    public class GetTransactionCommand : IRequest<string>
    {
        public Guid TransationId { get; set; }
    }
}
