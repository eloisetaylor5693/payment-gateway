using PaymentGateway.Models;
using System;

namespace PaymentGateway.BankPayment
{
    public class FailedBankPaymentResponse : IPaymentResponse
    {
        public Guid TransationId { get; set; }
        public bool TransactionSucessful { get; } = false;
        public string Message { get; set; }
    }
}
