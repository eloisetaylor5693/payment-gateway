using PaymentGateway.Models;

namespace PaymentGateway.Masking
{
    public interface IMaskSensitiveData
    {
        PaymentTransaction Mask(PaymentTransaction paymentTransaction);
    }
}
