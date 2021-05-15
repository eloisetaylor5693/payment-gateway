using PaymentGateway.Models;

namespace PaymentGateway.Masking
{
    public class MaskSensitiveData : IMaskSensitiveData
    {
        public PaymentTransaction Mask(PaymentTransaction paymentTransaction)
        {
            var cardNumber = paymentTransaction?.Card?.CardNumber ?? "0000 0000 0000 0000";

            var maskedCardNumber = $"**** **** **** {cardNumber.Substring(cardNumber.Length - 4, 4)}";

            var maskedTransaction = paymentTransaction;

            maskedTransaction.Card.CardNumber = maskedCardNumber;

            return maskedTransaction;
        }
    }
}
