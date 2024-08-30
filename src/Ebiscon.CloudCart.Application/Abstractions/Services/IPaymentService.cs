using Ebiscon.CloudCart.Domain.Entities;

namespace Ebiscon.CloudCart.Application.Abstractions.Services;

public interface IPaymentService
{
    Task<Payment> InsertPayment(Payment payment, CancellationToken cancellationToken);
    Task<Payment> GetPaymentById(long paymentId, CancellationToken cancellationToken);
    Task MakePayment(Payment payment, CancellationToken cancellationToken);
}
