using Ebiscon.CloudCart.Domain.Entities;
using Ebiscon.CloudCart.Domain.Abstractions;
using Ebiscon.CloudCart.Application.Abstractions.Services;

namespace Ebiscon.CloudCart.Application.Orders.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;

        public OrderService(IOrderRepository orderRepository, IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }

        public async Task CreateOrder(Order order, List<Product> products, CancellationToken cancellationToken)
        {
            products.ForEach(p =>
            {
                order.OrderProducts.Add(
                   new OrderProduct
                   {
                       ProductId = p.Id,
                       OrderId = order.Id,
                       Order = order,
                       Product = p,
                   });
            });

            await _orderRepository.InsertOrder(order, cancellationToken);
        }

        public Task<Order> GetOrderById(Guid orderId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }

}
