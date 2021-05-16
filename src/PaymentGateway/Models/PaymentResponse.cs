using System;

namespace PaymentGateway.Models
{
    public class PaymentResponse
    {
        public bool TransactionSucessful { get; set; }
        public Guid TransactionId { get; set; }
        public string Message { get; set; }

        public override string ToString()
        {
            return $"{TransactionId}, Successful? {TransactionSucessful}, {Message}";
        }
    }
}
