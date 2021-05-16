using PaymentGateway.Models;
using System;

namespace PaymentGateway.BankPayment
{
    public class FailedBankPaymentResponse : IBankTransactionResponse
    {
        public Guid TransactionId { get; set; }
        public bool TransactionSucessful { get; } = false;
        public string Message { get; set; }
        public PaymentStatus PaymentStatus { get; set; } 
    }
}
