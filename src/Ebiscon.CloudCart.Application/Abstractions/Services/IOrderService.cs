using Ebiscon.CloudCart.Domain.Entities;

namespace Ebiscon.CloudCart.Application.Abstractions.Services;

public interface IOrderService
{
    Task<Order> GetOrderById(Guid orderId, CancellationToken cancellationToken);
    Task CreateOrder(Order order, List<Product> products, CancellationToken cancellationToken);
}
