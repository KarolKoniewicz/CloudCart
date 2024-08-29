using MediatR;
using Ebiscon.CloudCart.Application.Products.Command;

namespace Ebiscon.CloudCart.Application.Products.CommandHandler;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand>
{
    public Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
