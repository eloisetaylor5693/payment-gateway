using PaymentGateway.Requests;
using System.Threading.Tasks;

namespace PaymentGateway.BankPayment
{
    public interface IMakeBankPaymentAdapter
    {
        Task<IBankTransactionResponse> PayAsync(MakeAPaymentRequest request);
    }
}
