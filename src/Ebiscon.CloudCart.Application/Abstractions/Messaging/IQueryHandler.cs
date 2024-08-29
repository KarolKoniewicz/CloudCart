using MediatR;
using Ebiscon.CloudCart.Domain.Shared;

namespace Ebiscon.CloudCart.Application.Abstractions.Messaging;

public interface IQueryHandler<TQuery, TResponse>
    : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>
{
}
