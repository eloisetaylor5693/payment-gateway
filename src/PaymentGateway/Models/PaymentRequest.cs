﻿using System;

namespace PaymentGateway.Models
{
    public class PaymentRequest : IPaymentRequest
    {
        public DateTime TransactionDate { get; set; }
        public int MerchantId { get; set; }
        public int TerminalId { get; set; }
        public double PaymentAmount { get; set; }
        public string IsoCurrencyCode { get; set; }
        public string PaymentReference { get; set; }
        public Card Card { get; set; }
    }
}
