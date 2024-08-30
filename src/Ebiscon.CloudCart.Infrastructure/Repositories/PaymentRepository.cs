using Ebiscon.CloudCart.Domain.Entities;
using Ebiscon.CloudCart.Domain.Abstractions;

namespace Ebiscon.CloudCart.Infrastructure.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        public Task<Payment> GetPaymentById(long paymentId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task InsertPayment(Payment payment, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
