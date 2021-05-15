using FluentValidation;
using MediatR;
using PaymentGateway.BankPayment;
using PaymentGateway.Models;
using PaymentGateway.Repository;
using PaymentGateway.Requests;
using Serilog.Context;
using System.Threading;
using System.Threading.Tasks;

namespace PaymentGateway.RequestHandlers
{
    public sealed class MakeAPaymentRequestHandler : IRequestHandler<MakeAPaymentRequest, PaymentResponse>
    {
        private readonly IMakeBankPaymentAdapter _bankPaymentAdapter;
        private readonly IValidator<MakeAPaymentRequest> _validator;
        private readonly IPaymentTransactionRepository _repository;

        public MakeAPaymentRequestHandler(
            IMakeBankPaymentAdapter bankPaymentAdapter, 
            IValidator<MakeAPaymentRequest> validator,
            IPaymentTransactionRepository repository)
        {
            _bankPaymentAdapter = bankPaymentAdapter;
            _validator = validator;
            _repository = repository;
        }

        public async Task<PaymentResponse> Handle(MakeAPaymentRequest request, CancellationToken cancellationToken)
        {
            using (LogContext.PushProperty("transactionId", request.TransationId))
            {
                await _validator.ValidateAndThrowAsync(request);

                // have I made the payment before?

                var responseFromBank = await _bankPaymentAdapter.PayAsync(request);

                var transaction = request.ToPaymentTransaction(responseFromBank);

                await _repository.SaveAsync(transaction);

                return new PaymentResponse
                {
                    TransactionSucessful = responseFromBank.TransactionSucessful,
                    TransationId = request.TransationId,
                    Message = responseFromBank.Message
                };
            }
        }
    }
}
