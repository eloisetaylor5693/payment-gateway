using MediatR;
using PaymentGateway.Models;
using System;

namespace PaymentGateway.Commands
{
    public class MakeAPaymentRequest : IPaymentRequest, IRequest<PaymentResponse>
    {
        public Guid TransationId { get; } = Guid.NewGuid();

        public DateTime TransactionDate { get; set; }

        public int MerchantId { get; set; }

        public int TerminalId { get; set; }

        public double PaymentAmount { get; set; }

        public string IsoCurrencyCode { get; set; }

        public string PaymentReference { get; set; }

        public Card Card { get; set; }
    }
}
