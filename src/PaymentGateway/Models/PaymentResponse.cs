using System;

namespace PaymentGateway.Models
{
    public class PaymentResponse : IPaymentResponse
    {
        public bool TransactionSucessful { get; set; }
        public Guid TransationId { get; set; }
        public string Message { get; set; }
    }
}
