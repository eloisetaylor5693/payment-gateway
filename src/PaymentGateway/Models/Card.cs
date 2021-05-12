namespace PaymentGateway.Models
{
    public class Card
    {
        public string NameOnCard { get; set; }

        /// <summary>
        /// mastercard/visa etc
        /// </summary>
        public string CardIssuer { get; set; }

        public string CardNumber { get; set; }

        /// <summary>
        /// MM/YY format
        /// </summary>
        public string ExpiryDate { get; set; }

        public int CVV { get; set; }
    }
}
