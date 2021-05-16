using Newtonsoft.Json;
using NUnit.Framework;
using PaymentGateway.BankPayment;
using PaymentGateway.Models;
using PaymentGateway.Requests;
using System;

namespace PaymentGateway.UnitTests
{
    [TestFixture]
    public sealed class MapperExtentionsTests
    {
        [Test]
        public void MapsCorrectly()
        {
            var actual = _request.ToPaymentTransaction(_responseFromBank);

            var actualInJsonFormat = JsonConvert.SerializeObject(actual);
            var expectedInJsonFormat = JsonConvert.SerializeObject(_expected);

            Assert.That(actualInJsonFormat, Is.EqualTo(expectedInJsonFormat));
        }

        private static readonly MakeAPaymentRequest _request = new MakeAPaymentRequest
        {
            TransactionDate = DateTime.UtcNow,
            MerchantId = "123456789012345",
            TerminalId = "12345678",
            IsoCurrencyCode = "GBP",
            PaymentAmount = 150.78,
            PaymentReference = "Order#6274",
            Card = new Card
            {
                NameOnCard = "Miss Anne Other",
                CardIssuer = "Visa",
                CardNumber = "4012888888881881",
                ExpiryDate = "05/25",
                CVV = 123
            }
        };

        private static readonly IBankTransactionResponse _responseFromBank = new SuccessfulBankPaymentResponse
        {
            TransactionId = Guid.NewGuid()
        };

        private readonly PaymentTransaction _expected = new PaymentTransaction
        {
            BankTransactionId = _responseFromBank.TransactionId,
            PaymentStatus = PaymentStatus.Success,
            TransactionSucessful = true,
            BankTransactionMessage = "Payment received",
            TransactionDate = _request.TransactionDate,
            TransactionId = _request.TransactionId,
            MerchantId = "123456789012345",
            TerminalId = "12345678",
            IsoCurrencyCode = "GBP",
            PaymentAmount = 150.78,
            PaymentReference = "Order#6274",
            Card = new Card
            {
                NameOnCard = "Miss Anne Other",
                CardIssuer = "Visa",
                CardNumber = "4012888888881881",
                ExpiryDate = "05/25",
                CVV = 123
            }
        };
    }
}
