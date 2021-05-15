using System;

namespace PaymentGateway.Models
{
    public class PaymentResponse
    {
        public bool TransactionSucessful { get; set; }
        public Guid TransationId { get; set; }
        public string Message { get; set; }

        public override string ToString()
        {
            return $"{TransationId}, Successful? {TransactionSucessful}, {Message}";
        }
    }
}
