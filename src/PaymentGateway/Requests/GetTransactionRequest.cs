using MediatR;
using PaymentGateway.Models;
using System;
using System.Diagnostics.CodeAnalysis;

namespace PaymentGateway.Requests
{
    [ExcludeFromCodeCoverage]
    public class GetTransactionRequest : IRequest<PaymentTransaction>
    {
        public Guid TransactionId { get; set; }

        public override string ToString()
        {
            return TransactionId.ToString();
        }
    }
}
