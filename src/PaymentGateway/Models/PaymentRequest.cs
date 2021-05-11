using System;

namespace PaymentGateway.Models
{
    public class PaymentRequest
    {
        public DateTime TransactionDate { get; set; }

        /// <summary>
        /// 15 digits long identification number for the merchant
        /// </summary>
        public int MerchantId { get; set; }

        /// <summary>
        /// 8 digits long identification number for the terminal 
        /// </summary>
        public int TerminalId { get; set; }

        public double PaymentAmount { get; set; }

        /// <summary>
        /// 3 characters
        /// https://www.foreignexchangelive.com/currency-codes-symbols/
        /// </summary>
        public string IsoCurrencyCode { get; set; }

        /// <summary>
        /// Something that relates to what the customer purchased for example order number
        /// </summary>
        public string PaymentReference { get; set; }

        public Card Card { get; set; }
    }
}
