using PaymentGateway.Models;
using System.Threading.Tasks;

namespace PaymentGateway.Repository
{
    public interface IPaymentTransactionRepository
    {
        Task SaveAsync(PaymentTransaction transaction);
    }
}
