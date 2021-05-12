using MediatR;
using PaymentGateway.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace PaymentGateway.Handlers
{
    public sealed class GetTransactionHandler : IRequestHandler<GetTransactionRequest, string>
    {
        public Task<string> Handle(GetTransactionRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult("Here's your payment information");
        }
    }
}
