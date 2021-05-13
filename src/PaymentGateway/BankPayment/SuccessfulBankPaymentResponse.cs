using PaymentGateway.Models;
using System;

namespace PaymentGateway.BankPayment
{
    public class SuccessfulBankPaymentResponse : IPaymentResponse
    {
        public Guid TransationId { get; set; }
        public bool TransactionSucessful { get; } = true;
        public string Message { get; } = "Payment received";
    }
}
