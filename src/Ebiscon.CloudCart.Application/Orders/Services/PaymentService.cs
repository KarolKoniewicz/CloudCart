using Ebiscon.CloudCart.Domain.Entities;
using Ebiscon.CloudCart.Application.Abstractions.Services;

namespace Ebiscon.CloudCart.Application.Orders.Services
{
    public class PaymentService : IPaymentService
    {
        public Task<Payment> GetPaymentById(long paymentId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Payment> InsertPayment(Payment payment, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task MakePayment(Payment payment, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }

}
