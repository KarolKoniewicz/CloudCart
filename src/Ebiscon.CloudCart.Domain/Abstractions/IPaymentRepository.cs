using Ebiscon.CloudCart.Domain.Entities;

namespace Ebiscon.CloudCart.Domain.Abstractions
{
    public interface IPaymentRepository
    {
        Task<Payment> GetPaymentById(long paymentId, CancellationToken cancellationToken);
        Task InsertPayment(Payment payment, CancellationToken cancellationToken);
    }

}
