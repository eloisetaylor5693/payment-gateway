using PaymentGateway.Models;
using System;
using System.Diagnostics.CodeAnalysis;

namespace PaymentGateway.BankPayment
{
    [ExcludeFromCodeCoverage]
    public class FailedBankPaymentResponse : IBankTransactionResponse
    {
        public Guid TransactionId { get; set; }
        public bool TransactionSucessful { get; } = false;
        public string Message { get; set; }
        public PaymentStatus PaymentStatus { get; set; } 
    }
}
