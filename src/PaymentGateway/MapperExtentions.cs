using PaymentGateway.BankPayment;
using PaymentGateway.Models;
using PaymentGateway.Requests;

namespace PaymentGateway
{
    public static class MapperExtentions
    {
        public static PaymentTransaction ToPaymentTransaction(this MakeAPaymentRequest request, IBankTransactionResponse responseFromBank)
        {
            return new PaymentTransaction
            {
                TransactionId = request.TransactionId,
                MerchantId = request.MerchantId,
                TerminalId = request.TerminalId,
                BankTransactionId = responseFromBank.TransactionId,
                PaymentStatus = responseFromBank.PaymentStatus,
                PaymentAmount = request.PaymentAmount,
                PaymentReference = request.PaymentReference,
                IsoCurrencyCode = request.IsoCurrencyCode,
                TransactionSucessful = responseFromBank.TransactionSucessful,
                BankTransactionMessage = responseFromBank.Message,
                TransactionDate = request.TransactionDate,
                Card = request.Card
            };
        }
    }
}
