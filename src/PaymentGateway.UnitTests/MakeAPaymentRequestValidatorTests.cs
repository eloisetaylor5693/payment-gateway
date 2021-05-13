using FluentValidation;
using NUnit.Framework;
using PaymentGateway.Models;
using PaymentGateway.Requests;
using PaymentGateway.Validation;
using System;

namespace PaymentGateway.UnitTests
{
    [TestFixture]
    public sealed class MakeAPaymentRequestValidatorTests
    {
        [Test]
        public void WhenValidRequest_PassesValidation()
        {
            var validator = new MakeAPaymentRequestValidator();

            validator.ValidateAndThrow(ValidRequest());
        }

        [TestCase("")]
        [TestCase("123")]
        [TestCase("ABCDE")]
        [TestCase(null)]
        [Test]
        public void WhenInvalidCurrency_FailsValidation(string invalidCurrencyCode)
        {
            var invalidRequest = ValidRequest();
            invalidRequest.IsoCurrencyCode = invalidCurrencyCode;

            var validator = new MakeAPaymentRequestValidator();

            Assert.Throws<ValidationException>(() => validator.ValidateAndThrow(invalidRequest));
        }

        [TestCase(0)]
        [TestCase(-5)]
        [TestCase(int.MaxValue)]
        [TestCase(int.MinValue)]
        [TestCase(5000)]
        [TestCase(null)]
        [Test]
        public void WhenInvalidPaymentAmount_FailsValidation(int invalidPaymentAmount)
        {
            var invalidRequest = ValidRequest();
            invalidRequest.PaymentAmount = invalidPaymentAmount;

            var validator = new MakeAPaymentRequestValidator();

            Assert.Throws<ValidationException>(() => validator.ValidateAndThrow(invalidRequest));
        }

        [TestCase("")]
        [TestCase("123")]
        [TestCase("ABCDEFGHIJKLMNO")]
        [TestCase("...............")]
        [TestCase("-12345678901234")]
        [TestCase(null)]
        [Test]
        public void WhenInvalidMerchantId_FailsValidation(string invalidMerchantId)
        {
            var invalidRequest = ValidRequest();
            invalidRequest.MerchantId = invalidMerchantId;

            var validator = new MakeAPaymentRequestValidator();

            Assert.Throws<ValidationException>(() => validator.ValidateAndThrow(invalidRequest));
        }

        [TestCase("")]
        [TestCase("123")]
        [TestCase("ABCDEFGH")]
        [TestCase("........")]
        [TestCase("-1234567")]
        [TestCase(null)]
        [Test]
        public void WhenInvalidTerminalId_FailsValidation(string invalidTerminalId)
        {
            var invalidRequest = ValidRequest();
            invalidRequest.TerminalId = invalidTerminalId;

            var validator = new MakeAPaymentRequestValidator();

            Assert.Throws<ValidationException>(() => validator.ValidateAndThrow(invalidRequest));
        }

        [TestCase("")]
        [TestCase(null)]
        [TestCase("£300 for my sofa")]
        [TestCase("this is a longer string than is accepted by the validation rules")]
        [Test]
        public void WhenInvalidPaymentReference_FailsValidation(string invalidPaymentReference)
        {
            var invalidRequest = ValidRequest();
            invalidRequest.PaymentReference = invalidPaymentReference;

            var validator = new MakeAPaymentRequestValidator();

            Assert.Throws<ValidationException>(() => validator.ValidateAndThrow(invalidRequest));
        }

        private MakeAPaymentRequest ValidRequest() =>
                new MakeAPaymentRequest
                {
                    TransactionDate = DateTime.Now,
                    MerchantId = "123456789012345",
                    TerminalId = "12345678",
                    IsoCurrencyCode = "GBP",
                    PaymentAmount = 150.78,
                    PaymentReference = "Order#6274",
                    Card = new Card
                    {
                        NameOnCard = "Miss Anne Other",
                        CardNumber = "1234123412341234",
                        ExpiryDate = "05/25",
                        CVV = 123
                    }
                };
    }
}