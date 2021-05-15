using PaymentGateway.Models;
using PaymentGateway.Requests;
using System;
using System.Threading.Tasks;

namespace PaymentGateway.Repository
{
    public interface IPaymentTransactionRepository
    {
        Task SaveAsync(PaymentTransaction transaction);
        Task<PaymentTransaction> GetPaymentTransaction(Guid transactionId);
        Task<PaymentTransaction> GetPaymentTransaction(MakeAPaymentRequest request);
    }
}
