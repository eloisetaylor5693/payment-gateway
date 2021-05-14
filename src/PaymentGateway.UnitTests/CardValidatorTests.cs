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

        [TestCase("")]
        [TestCase(null)]
        [TestCase("Discover")]
        [TestCase("Switch/Solo")]
        [Test]
        public void WhenInvalidCardIssuer_FailsValidation(string invalidCardIssuer)
        {
            var invalidRequest = ValidCard;
            invalidRequest.CardIssuer = invalidCardIssuer;

            var validator = new CardValidator();

            validator.ValidateAndThrow(ValidCard);
        }

        [TestCase(0)]
        [TestCase(99)]
        [TestCase(-99)]
        [TestCase(1000)]
        [TestCase(int.MinValue)]
        [Test]
        public void WhenInvalidCVV_FailsValidation(int invalidCVV)
        {
            var invalidRequest = ValidCard;
            invalidRequest.CVV = invalidCVV;

            var validator = new CardValidator();

            validator.ValidateAndThrow(ValidCard);
        }

        [TestCase("")]
        [TestCase(null)]
        [TestCase("123/554")]
        [TestCase("0123")]
        [Test]
        public void WhenInvalidExpiryDate_FailsValidation(string invalidExpiryDate)
        {
            var invalidRequest = ValidCard;
            invalidRequest.ExpiryDate = invalidExpiryDate;

            var validator = new CardValidator();

            validator.ValidateAndThrow(ValidCard);
        }

        private Card ValidCard => new Card
        {
            NameOnCard = "Miss Anne Other",
            CardNumber = "6331101999990016",
            CardIssuer = "Visa",
            ExpiryDate = "05/25",
            CVV = 123
        };
    }
}
