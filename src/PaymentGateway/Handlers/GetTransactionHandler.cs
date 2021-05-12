using MediatR;
using PaymentGateway.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace PaymentGateway.Handlers
{
    public sealed class GetTransactionHandler : IRequestHandler<GetTransactionCommand, string>
    {
        public Task<string> Handle(GetTransactionCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult("Here's your payment information");
        }
    }
}
