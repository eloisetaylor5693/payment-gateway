using System;

namespace PaymentGateway.Models
{
    public interface IPaymentResponse
    {
        string Message { get;  }
        bool TransactionSucessful { get;  }
        Guid TransationId { get; }
    }
}