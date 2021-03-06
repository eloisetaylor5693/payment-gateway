using System;
using System.Diagnostics.CodeAnalysis;

namespace PaymentGateway.Models
{
    [ExcludeFromCodeCoverage]
    public class PaymentTransaction : IBasicPaymentData
    {
        public Guid TransactionId { get; set; }

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

        public string BankTransactionMessage { get; set; }

        public override string ToString()
        {
            return $"{TransactionId}, {PaymentReference}, {PaymentAmount}, Successful? {TransactionSucessful}";
        }
    }
}
