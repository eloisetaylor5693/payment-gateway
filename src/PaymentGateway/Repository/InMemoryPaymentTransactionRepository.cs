using PaymentGateway.Models;
using PaymentGateway.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentGateway.Repository
{
    public class InMemoryPaymentTransactionRepository : IPaymentTransactionRepository
    {
        private readonly IList<PaymentTransaction> _paymentTransactions;

        public InMemoryPaymentTransactionRepository()
        {
            _paymentTransactions = new List<PaymentTransaction>();

            SeedTestData();
        }

        public Task<PaymentTransaction> GetPaymentTransaction(Guid transactionId)
        {
            return Task.FromResult(
                _paymentTransactions
                    .SingleOrDefault(x => x.TransationId == transactionId));
        }

        public Task<PaymentTransaction> GetPaymentTransaction(MakeAPaymentRequest request)
        {
            return Task.FromResult(
                _paymentTransactions
                    .SingleOrDefault(x => x.TransactionDate == request.TransactionDate &&
                                 x.MerchantId == request.MerchantId &&
                                 x.TerminalId == request.TerminalId &&
                                 x.PaymentReference == request.PaymentReference &&
                                 x.PaymentAmount == request.PaymentAmount &&
                                 x.IsoCurrencyCode == request.IsoCurrencyCode &&
                                 x.Card.CardNumber == request.Card.CardNumber
                    ));
        }

        public async Task SaveAsync(PaymentTransaction transaction)
        {
            await Task.Run(() => 
                _paymentTransactions.Add(transaction)
            );
        }

        private void SeedTestData()
        {
            _paymentTransactions.Add(new PaymentTransaction
            {
                TransationId = new Guid("6fa85f64-5717-4562-b3fc-2c963f66afa9"),
                BankTransactionId = new Guid("12a3d345-5717-4562-b3fc-2c963f66afa9"),
                TransactionDate = new DateTime(2021,01,29,3,52,22),
                MerchantId = "123456789012345",
                TerminalId = "12345678",
                IsoCurrencyCode = "GBP",
                PaymentAmount = 275.69,
                PaymentReference = "Order#9876",
                TransactionSucessful = true,
                PaymentStatus = PaymentStatus.Success,
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
