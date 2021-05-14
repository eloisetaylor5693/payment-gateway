using FluentValidation;
using NUnit.Framework;
using PaymentGateway.Models;
using PaymentGateway.Validation;

namespace PaymentGateway.UnitTests
{
    [TestFixture]
    public sealed class CardValidatorTests
    {
        [Test]
        public void PassesValidation()
        {
            var validator = new CardValidator();

            validator.ValidateAndThrow(ValidCard);
        }

        [TestCase("")]
        [TestCase(null)]
        [TestCase("1")]
        [TestCase("1234123412341234")]
        [TestCase("1234 1234 1234 1234")]
        [Test]
        public void WhenInvalidCardNumber_FailsValidation(string invalidCardNumber)
        {
            var invalidRequest = ValidCard;
            invalidRequest.CardNumber = invalidCardNumber;

            var validator = new CardValidator();

            validator.ValidateAndThrow(ValidCard);
        }

        [TestCase("")]
        [TestCase(null)]
        [TestCase("1")]
        [TestCase("Ms Anne-Other Test")]
        [TestCase("Sean O'doherty")]
        [TestCase("Ali")]
        [Test]
        public void WhenInvalidName_FailsValidation(string invalidNameOnCard)
        {
            var invalidRequest = ValidCard;
            invalidRequest.NameOnCard = invalidNameOnCard;

            var validator = new CardValidator();

            validator.ValidateAndThrow(ValidCard);
        }

        private Card ValidCard => new Card
        {
            NameOnCard = "Miss Anne Other",
            CardNumber = "6331101999990016",
            ExpiryDate = "05/25",
            CVV = 123
        };
    }
}
