using MediatR;
using PaymentGateway.Masking;
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
        private readonly IMaskSensitiveData _masker;

        public GetTransactionRequestHandler(IPaymentTransactionRepository repository, IMaskSensitiveData masker)
        {
            _repository = repository;
            _masker = masker;
        }

        public async Task<PaymentTransaction> Handle(GetTransactionRequest request, CancellationToken cancellationToken)
        {
            var transaction = await _repository.GetPaymentTransaction(request.TransactionId);

            return _masker.Mask(transaction);
        }
    }
}
