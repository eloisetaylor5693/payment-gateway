using PaymentGateway.Models;
using System;
using System.Diagnostics.CodeAnalysis;

namespace PaymentGateway.BankPayment
{
    [ExcludeFromCodeCoverage]
    public class SuccessfulBankPaymentResponse : IBankTransactionResponse
    {
        public Guid TransactionId { get; set; }
        public bool TransactionSucessful { get; } = true;
        public string Message { get; } = "Payment received";
        public PaymentStatus PaymentStatus { get; } = PaymentStatus.Success;
    }
}
