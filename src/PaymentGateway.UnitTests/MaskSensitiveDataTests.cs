using NUnit.Framework;
using PaymentGateway.Masking;
using PaymentGateway.Models;

namespace PaymentGateway.UnitTests
{
    [TestFixture]
    public sealed class MaskSensitiveDataTests
    {
        [Test]
        public void MasksCardCorrectly()
        {
            var payment = new PaymentTransaction
            {
                Card = new Card
                {
                    CardNumber = "1234 5678 9012 3456"
                }
            };

            var sut = new MaskSensitiveData();

            var results = sut.Mask(payment);

            Assert.That(results.Card.CardNumber, Is.EqualTo("**** **** **** 3456"));
        }
    }
}
