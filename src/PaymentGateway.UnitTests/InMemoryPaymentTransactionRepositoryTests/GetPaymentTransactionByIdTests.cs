using NUnit.Framework;
using PaymentGateway.Repository;
using System;
using System.Threading.Tasks;

namespace PaymentGateway.UnitTests.InMemoryPaymentTransactionRepositoryTests
{
    [TestFixture]
    public sealed class GetPaymentTransactionByIdTests
    {
        [Test]
        public async Task GivenATransactionIdThatExists_ShouldReturnThePayment()
        {
            var sut = new InMemoryPaymentTransactionRepository();

            var result = await sut.GetPaymentTransaction(new Guid("6fa85f64-5717-4562-b3fc-2c963f66afa9"));

            Assert.That(result, Is.Not.Null);
            Assert.That(result.PaymentReference, Is.EqualTo("Order#9876"));
        }

        [Test]
        public async Task GivenATransactionIdThatIsntFound_ShouldReturnNull()
        {
            var sut = new InMemoryPaymentTransactionRepository();

            var result = await sut.GetPaymentTransaction(new Guid());

            Assert.That(result, Is.Null);
        }
    }
}
