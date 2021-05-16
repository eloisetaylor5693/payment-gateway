using PaymentGateway.Models;
using System;

namespace PaymentGateway.BankPayment
{
    public interface IBankTransactionResponse
    {
        Guid TransactionId { get; }
        bool TransactionSucessful { get; }
        PaymentStatus PaymentStatus { get; }
        string Message { get; }
    }
}
