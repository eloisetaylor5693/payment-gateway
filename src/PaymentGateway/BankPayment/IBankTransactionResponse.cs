using PaymentGateway.Models;
using System;

namespace PaymentGateway.BankPayment
{
    public interface IBankTransactionResponse
    {
        Guid TransationId { get; }
        bool TransactionSucessful { get; }
        PaymentStatus PaymentStatus { get; }
        string Message { get; }
    }
}
