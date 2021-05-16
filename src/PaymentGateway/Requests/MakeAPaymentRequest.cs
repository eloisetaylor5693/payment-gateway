using MediatR;
using PaymentGateway.Models;
using System;
using System.Diagnostics.CodeAnalysis;

namespace PaymentGateway.Requests
{
    [ExcludeFromCodeCoverage]
    public class MakeAPaymentRequest : IBasicPaymentData, IRequest<PaymentResponse>
    {
        public Guid TransactionId { get; } = Guid.NewGuid();

        public DateTime TransactionDate { get; set; }

        public string MerchantId { get; set; }

        public string TerminalId { get; set; }

        public double PaymentAmount { get; set; }

        public string IsoCurrencyCode { get; set; }

        public string PaymentReference { get; set; }

        public Card Card { get; set; }

        public override string ToString()
        {
            return $"{TransactionId}, {PaymentReference}, {PaymentAmount}";
        }
    }
}
