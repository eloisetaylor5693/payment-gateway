using MediatR;
using PaymentGateway.Models;
using System;

namespace PaymentGateway.Requests
{
    public class MakeAPaymentRequest : IBasicPaymentData, IRequest<PaymentResponse>
    {
        public Guid TransationId { get; } = Guid.NewGuid();

        public DateTime TransactionDate { get; set; }

        public string MerchantId { get; set; }

        public string TerminalId { get; set; }

        public double PaymentAmount { get; set; }

        public string IsoCurrencyCode { get; set; }

        public string PaymentReference { get; set; }

        public Card Card { get; set; }

        public override string ToString()
        {
            return $"{TransationId}, {PaymentReference}, {PaymentAmount}";
        }
    }
}
