using NUnit.Framework;
using PaymentGateway.Models;
using PaymentGateway.Repository;
using PaymentGateway.Requests;
using System;
using System.Threading.Tasks;

namespace PaymentGateway.UnitTests.InMemoryPaymentTransactionRepositoryTests
{
    [TestFixture]
    public sealed class GetPaymentTransactionByRequestTests
    {
        [Test]
        public async Task GivenATransactionThatExists_ShouldReturnThePayment()
        {
            var sut = new InMemoryPaymentTransactionRepository();

            var result = await sut.GetPaymentTransaction(RequestForFindingTransaction);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.PaymentReference, Is.EqualTo("Order#9876"));
        }

        [Test]
        public async Task GivenATransactionThatIsntFound_ShouldReturnNull()
        {
            var sut = new InMemoryPaymentTransactionRepository();

            var result = await sut.GetPaymentTransaction(new MakeAPaymentRequest());

            Assert.That(result, Is.Null);
        }


        private static MakeAPaymentRequest RequestForFindingTransaction =>
                new MakeAPaymentRequest
                {
                    TransactionDate = new DateTime(2021, 01, 29, 3, 52, 22),
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
