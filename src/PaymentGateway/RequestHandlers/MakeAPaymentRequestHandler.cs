using MediatR;
using PaymentGateway.BankPayment;
using PaymentGateway.Models;
using PaymentGateway.Requests;
using System.Threading;
using System.Threading.Tasks;

namespace PaymentGateway.RequestHandlers
{
    public sealed class MakeAPaymentRequestHandler : IRequestHandler<MakeAPaymentRequest, PaymentResponse>
    {
        private readonly IMakeBankPaymentAdapter _bankPaymentAdapter;

        public MakeAPaymentRequestHandler(IMakeBankPaymentAdapter bankPaymentAdapter)
        {
            _bankPaymentAdapter = bankPaymentAdapter;
        }

        public Task<PaymentResponse> Handle(MakeAPaymentRequest request, CancellationToken cancellationToken)
        {
            var response = _bankPaymentAdapter.Pay(request);

            return Task.FromResult(new PaymentResponse
            {
                TransactionSucessful = response.TransactionSucessful,
                TransationId = request.TransationId,
                Message = response.Message
            });
        }
    }
}
