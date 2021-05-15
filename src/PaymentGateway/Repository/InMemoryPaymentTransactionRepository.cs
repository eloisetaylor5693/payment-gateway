using PaymentGateway.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PaymentGateway.Repository
{
    public class InMemoryPaymentTransactionRepository : IPaymentTransactionRepository
    {
        private IList<PaymentTransaction> paymentTransactions = new List<PaymentTransaction>();

        public InMemoryPaymentTransactionRepository()
        {
            SeedTestData();
        }

        public async Task SaveAsync(PaymentTransaction transaction)
        {
            await Task.Run(() => 
                paymentTransactions.Add(transaction)
            );
        }

        private void SeedTestData()
        {
            paymentTransactions.Add(new PaymentTransaction
            {
                TransationId = new Guid("6fa85f64-5717-4562-b3fc-2c963f66afa9"),
                TransactionDate = new DateTime(2021,01,29,3,52,22),
                MerchantId = "123456789012345",
                TerminalId = "12345678",
                IsoCurrencyCode = "GBP",
                PaymentAmount = 275.69,
                PaymentReference = "Order#9876",
                Card = new Card
                {
                    NameOnCard = "Miss Anne Other",
                    CardIssuer = "Visa",
                    CardNumber = "4012888888881881",
                    ExpiryDate = "05/25",
                    CVV = 123
                }
            });
        }
    }
}
