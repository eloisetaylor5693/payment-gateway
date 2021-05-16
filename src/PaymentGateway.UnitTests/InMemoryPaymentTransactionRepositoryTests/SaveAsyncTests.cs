using NUnit.Framework;
using PaymentGateway.Models;
using PaymentGateway.Repository;
using System;
using System.Threading.Tasks;

namespace PaymentGateway.UnitTests.InMemoryPaymentTransactionRepositoryTests
{
    [TestFixture]
    public sealed class SaveAsyncTests
    {
        [Test]
        public async Task GivenANewTransaction_ShouldSave()
        {
            var sut = new InMemoryPaymentTransactionRepository();

            var payment = Payment();

            await sut.SaveAsync(payment);

            await HasStoredTheTransaction(sut, payment);
        }

        [Test]
        public async Task GivenATransactionIdThatExists_ShouldNotSave()
        {
            var sut = new InMemoryPaymentTransactionRepository();

            var payment = Payment();

            // saving the same payment twice
            await sut.SaveAsync(payment);
            await sut.SaveAsync(payment);

            await HasStoredTheTransaction(sut, payment);
        }

        private static async Task HasStoredTheTransaction(InMemoryPaymentTransactionRepository sut, PaymentTransaction payment)
        {
            var result = await sut.GetPaymentTransaction(payment.TransactionId);

            Assert.That(result, Is.Not.Null);
        }

        private static PaymentTransaction Payment() =>
                new PaymentTransaction
                {
                    TransactionId = Guid.NewGuid(),
                    TransactionDate = DateTime.Now,
                    MerchantId = "123456789012345",
                    TerminalId = "12345678",
                    IsoCurrencyCode = "GBP",
                    PaymentAmount = 275.69,
                    PaymentReference = "Order#9876",
                    Card = new Card
                    {
                        CardNumber = "4012888888881881",
                    }
                };
    }
}
