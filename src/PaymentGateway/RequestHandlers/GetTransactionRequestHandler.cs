using MediatR;
using PaymentGateway.Models;
using PaymentGateway.Repository;
using PaymentGateway.Requests;
using System.Threading;
using System.Threading.Tasks;

namespace PaymentGateway.RequestHandlers
{
    public sealed class GetTransactionRequestHandler : IRequestHandler<GetTransactionRequest, PaymentTransaction>
    {
        private readonly IPaymentTransactionRepository _repository;

        public GetTransactionRequestHandler(IPaymentTransactionRepository repository)
        {
            _repository = repository;
        }

        public async Task<PaymentTransaction> Handle(GetTransactionRequest request, CancellationToken cancellationToken)
        {
            return await _repository.GetPaymentTransaction(request.TransactionId);
        }
    }
}
