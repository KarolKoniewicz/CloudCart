using Ebiscon.CloudCart.Database;
using Microsoft.EntityFrameworkCore;
using Ebiscon.CloudCart.Domain.Entities;
using Ebiscon.CloudCart.Domain.Abstractions;

namespace Ebiscon.CloudCart.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext context;

        public OrderRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<Order> GetOrderById(Guid orderId, CancellationToken cancellationToken)
            => await context.Orders.FirstOrDefaultAsync(x => x.Id == orderId, cancellationToken);

        public async Task InsertOrder(Order order, CancellationToken cancellationToken)
        {
            context.Orders.Add(order);
            await context.SaveChangesAsync(cancellationToken);
        }
    }
}
