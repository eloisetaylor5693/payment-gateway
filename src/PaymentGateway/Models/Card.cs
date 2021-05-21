using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace PaymentGateway.Models
{
    [ExcludeFromCodeCoverage]
    public class Card
    {
        public string NameOnCard { get; set; }

        /// <summary>
        /// mastercard/visa etc
        /// </summary>
        [DefaultValue("visa")]
        public string CardIssuer { get; set; }

        [DefaultValue("4111111111111111")]
        public string CardNumber { get; set; }

        /// <summary>
        /// MM/YY format
        /// </summary>
        [DefaultValue("11/55")]
        public string ExpiryDate { get; set; }

        [DefaultValue("666")]
        public int CVV { get; set; }
    }
}
