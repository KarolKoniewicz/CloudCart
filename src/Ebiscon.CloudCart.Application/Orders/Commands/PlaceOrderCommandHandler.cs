using MediatR;
using Ebiscon.CloudCart.Domain.Entities;
using Ebiscon.CloudCart.Application.Abstractions.Services;

namespace Ebiscon.CloudCart.Application.Orders.Commands;

public sealed class PlaceOrderCommandHandler : IRequestHandler<PlaceOrderCommand>
{
    private readonly IApplicationUserService applicationUserService;
    private readonly IOrderService orderService;
    private readonly IPaymentService paymentService;
    private readonly IProductService productService;

    public PlaceOrderCommandHandler(
        IOrderService orderService,
        IPaymentService paymentService,
        IApplicationUserService applicationUserService,
        IProductService productService)
    {
        this.orderService = orderService;
        this.paymentService = paymentService;
        this.applicationUserService = applicationUserService;
        this.productService = productService;
    }

    public async Task Handle(PlaceOrderCommand request, CancellationToken cancellationToken)
    {
        var orderRequest = request.OrderRequest;

        var user = await applicationUserService.GetApplicationUserById(orderRequest.UserId, cancellationToken);

        var products = new List<Product>();

        foreach (var productId in orderRequest.ProductIds)
        {
            var productFetched = await productService.GetProductById(productId, cancellationToken);
            products.Add(productFetched);
        }

        var order = new Order().Create(user);
        var payment = new Payment().Create(user);

        await orderService.CreateOrder(order, products, cancellationToken);
        await paymentService.InsertPayment(payment, cancellationToken);
    }
}