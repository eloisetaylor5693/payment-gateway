using System;

namespace PaymentGateway.Models
{
    public class PaymentTransaction : IBasicPaymentData
    {
        public Guid TransationId { get; set; }

        public Guid BankTransactionId { get; set; }

        public DateTime TransactionDate { get; set; }

        public string MerchantId { get; set; }

        public string TerminalId { get; set; }

        public double PaymentAmount { get; set; }

        public string IsoCurrencyCode { get; set; }

        public string PaymentReference { get; set; }

        public Card Card { get; set; }

        public bool TransactionSucessful { get; set; }

        public PaymentStatus PaymentStatus { get; set; }
    }
}
