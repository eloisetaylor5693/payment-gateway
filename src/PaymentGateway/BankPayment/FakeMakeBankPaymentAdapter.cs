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

            return new SuccessfulBankPaymentResponse
            {
                TransationId = fakeBankTransactionId
            };
        }
    }
}
