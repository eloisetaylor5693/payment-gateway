using PaymentGateway.Models;
using PaymentGateway.Requests;
using Serilog;
using System;
using System.Threading.Tasks;

namespace PaymentGateway.BankPayment
{
    public class FakeBankPaymentAdapter : IMakeBankPaymentAdapter
    {
        private ILogger _logger;

        public FakeBankPaymentAdapter()
        {
            _logger = Log.ForContext<FakeBankPaymentAdapter>();
        }

        public async Task<IBankTransactionResponse> PayAsync(MakeAPaymentRequest request)
        {
            var fakeBankTransactionId = Guid.NewGuid();

            if (request.PaymentAmount > 200)
            {
                _logger.Warning("Payment request to the bank failed");

                return await Task.FromResult(new FailedBankPaymentResponse
                {
                    TransactionId = fakeBankTransactionId,
                    PaymentStatus = PaymentStatus.NotEnoughFunds,
                    Message = "Not enough funds to make the payment"
                });
            }

            return await Task.FromResult(new SuccessfulBankPaymentResponse
            {
                TransactionId = fakeBankTransactionId
            });
        }
    }
}
