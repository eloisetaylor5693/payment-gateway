namespace PaymentGateway.Models
{
    public enum PaymentStatus
    {
        Unknown = 0,
        Success = 1,
        NotEnoughFunds = 2,
        CardFrozen = 3,
        SuspiciousActivity = 4,

        // Leaving space for other failure statuses before this one
        DeclinedForOtherReason = 20
    }
}
