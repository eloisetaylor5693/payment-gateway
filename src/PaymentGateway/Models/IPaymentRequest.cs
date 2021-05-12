using System;

namespace PaymentGateway.Models
{
    public interface IPaymentRequest
    {
        Card Card { get; set; }

        /// <summary>
        /// 3 characters
        /// https://www.foreignexchangelive.com/currency-codes-symbols/
        /// </summary>
        string IsoCurrencyCode { get; set; }

        /// <summary>
        /// 15 digits long identification number for the merchant
        /// </summary>
        int MerchantId { get; set; }

        double PaymentAmount { get; set; }

        string PaymentReference { get; set; }

        /// <summary>
        /// 8 digits long identification number for the terminal 
        /// </summary>
        int TerminalId { get; set; }

        DateTime TransactionDate { get; set; }
    }
}