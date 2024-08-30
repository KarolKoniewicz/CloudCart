using Ebiscon.CloudCart.Domain.Entities;

namespace Ebiscon.CloudCart.Domain.Abstractions
{
    public interface IOrderRepository
    {
        Task<Order> GetOrderById(Guid orderId, CancellationToken cancellationToken);
        Task InsertOrder(Order order, CancellationToken cancellationToken);
    }
}
