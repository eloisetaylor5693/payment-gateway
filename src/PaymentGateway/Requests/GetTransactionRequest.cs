using MediatR;
using PaymentGateway.Models;
using System;

namespace PaymentGateway.Requests
{
    public class GetTransactionRequest : IRequest<PaymentTransaction>
    {
        public Guid TransactionId { get; set; }

        public override string ToString()
        {
            return TransactionId.ToString();
        }
    }
}
