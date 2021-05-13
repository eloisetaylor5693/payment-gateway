using MediatR;
using PaymentGateway.Requests;
using System.Threading;
using System.Threading.Tasks;

namespace PaymentGateway.RequestHandlers
{
    public sealed class GetTransactionRequestHandler : IRequestHandler<GetTransactionRequest, string>
    {
        public Task<string> Handle(GetTransactionRequest request, CancellationToken cancellationToken)
        {
            // try and find transaction

            // return data

            return Task.FromResult("Here's your payment information");
        }
    }
}
