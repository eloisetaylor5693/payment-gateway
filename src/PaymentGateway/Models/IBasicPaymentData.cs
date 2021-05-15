using System;

namespace PaymentGateway.Models
{
    /// <summary>
    /// Exists so that the XML comments are persisted in all places these properties are used.
    /// I can document centrally in the interface, and when you hover over the property anywhere 
    /// in code you see explanations of some of the properties
    /// </summary>
    public interface IBasicPaymentData
    {
        Card Card { get; }

        /// <summary>
        /// 3 characters ISO Currency code eg GBP: 
        /// <see href="https://www.foreignexchangelive.com/currency-codes-symbols/"/>
        /// </summary>
        string IsoCurrencyCode { get; }

        /// <summary>
        /// 15 digit long identification number for the merchant: 
        /// <see href="https://tidalcommerce.com/learn/merchant-id-number"/>
        /// </summary>
        string MerchantId { get; }

        double PaymentAmount { get; }

        /// <summary>
        /// Reference for the merchant to correlate to their own records.  
        /// Also will likely show on the customer's bank statement
        /// </summary>
        string PaymentReference { get; }

        /// <summary>
        /// 8 digit long identification number for the terminal:  
        /// <see href="https://www.opayo.co.uk/support/28/36/terminal-id-s"/>
        /// </summary>
        string TerminalId { get; }

        /// <summary>
        /// Date the transaction was attempted by the customer
        /// </summary>
        DateTime TransactionDate { get; }
    }
}