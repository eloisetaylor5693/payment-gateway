using MediatR;
using PaymentGateway.Models;
using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace PaymentGateway.Requests
{
    [ExcludeFromCodeCoverage]
    public class MakeAPaymentRequest : IBasicPaymentData, IRequest<PaymentResponse>
    {
        public Guid TransactionId { get; } = Guid.NewGuid();

        public DateTime TransactionDate { get; set; }

        [DefaultValue(123456789012345)]
        public string MerchantId { get; set; }

        [DefaultValue(12345678)]
        public string TerminalId { get; set; }

        [DefaultValue(15.00)]
        public double PaymentAmount { get; set; }

        [DefaultValue("GBP")]
        public string IsoCurrencyCode { get; set; }

        [DefaultValue("Swagger1")]
        public string PaymentReference { get; set; }

        public Card Card { get; set; }

        public override string ToString()
        {
            return $"{TransactionId}, {PaymentReference}, {PaymentAmount}";
        }
    }
}
