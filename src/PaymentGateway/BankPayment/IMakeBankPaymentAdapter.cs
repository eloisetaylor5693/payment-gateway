using PaymentGateway.Models;
using PaymentGateway.Requests;

namespace PaymentGateway.BankPayment
{
    public interface IMakeBankPaymentAdapter
    {
        IPaymentResponse Pay(MakeAPaymentRequest request);
    }
}
