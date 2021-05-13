using PaymentGateway.Models;
using PaymentGateway.Requests;
using Serilog;
using System;
using System.Threading.Tasks;

namespace PaymentGateway.BankPayment
{
    public class FakeMakeBankPaymentAdapter : IMakeBankPaymentAdapter
    {
        private ILogger _logger;

        public FakeMakeBankPaymentAdapter()
        {
            _logger = Log.ForContext<FakeMakeBankPaymentAdapter>();
        }

        public async Task<IPaymentResponse> PayAsync(MakeAPaymentRequest request)
        {
            var fakeBankTransactionId = Guid.NewGuid();

            if (request.PaymentAmount > 200)
            {
                _logger.Warning("Payment request to the bank failed");

                return await Task.FromResult(new FailedBankPaymentResponse
                {
                    TransationId = fakeBankTransactionId,
                    Message = "Not enough funds to make the payment"
                });
            }

            return await Task.FromResult(new SuccessfulBankPaymentResponse
            {
                TransationId = fakeBankTransactionId
            });
        }
    }
}
