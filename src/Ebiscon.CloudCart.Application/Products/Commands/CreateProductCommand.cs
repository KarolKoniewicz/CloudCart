using MediatR;

namespace Ebiscon.CloudCart.Application.Products.Command;

public sealed record CreateProductCommand(string name, decimal price, int quantity) : IRequest;
