using PaymentGateway.Models;
using PaymentGateway.Requests;
using System;

namespace PaymentGateway.BankPayment
{
    public class FakeMakeBankPaymentAdapter : IMakeBankPaymentAdapter
    {
        public IPaymentResponse Pay(MakeAPaymentRequest request)
        {
            var fakeBankTransactionId = Guid.NewGuid();

            if (request.PaymentAmount > 200)
            {
                return new FailedBankPaymentResponse
                {
                    TransationId = fakeBankTransactionId,
                    Message = "Not enough funds to make the payment"
                };
            }

            return new SuccessfulBankPaymentResponse
            {
                TransationId = fakeBankTransactionId
            };
        }
    }
}
