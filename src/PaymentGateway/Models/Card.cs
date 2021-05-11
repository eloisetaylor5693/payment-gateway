namespace PaymentGateway.Models
{
    public class Card : IPaymentMethod
    {
        public string NameOnCard { get; set; }

        /// <summary>
        /// mastercard/visa etc
        /// </summary>
        public string CardIssuer { get; set; }

        public int CardNumber { get; set; }
        public string ExpiryDate { get; set; }
        public int CVV { get; set; }
    }
}
