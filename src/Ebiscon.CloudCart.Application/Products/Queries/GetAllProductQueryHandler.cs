using Ebiscon.CloudCart.Domain.Shared;
using Ebiscon.CloudCart.Application.Products.Contracts;
using Ebiscon.CloudCart.Application.Abstractions.Messaging;

namespace Ebiscon.CloudCart.Application.Products.Queries;

public class GetAllProductQueryHandler : IQueryHandler<GetAllProductQuery, ProductResponse>
{
    public Task<Result<ProductResponse>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
