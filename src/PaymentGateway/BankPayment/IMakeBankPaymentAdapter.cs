using PaymentGateway.Models;
using PaymentGateway.Requests;
using System.Threading.Tasks;

namespace PaymentGateway.BankPayment
{
    public interface IMakeBankPaymentAdapter
    {
        Task<IPaymentResponse> PayAsync(MakeAPaymentRequest request);
    }
}
