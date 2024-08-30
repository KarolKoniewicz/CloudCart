using MediatR;
using Ebiscon.CloudCart.Domain.Contracts;

namespace Ebiscon.CloudCart.Application.Orders.Commands;

public sealed record PlaceOrderCommand(OrderRequest OrderRequest) : IRequest;
