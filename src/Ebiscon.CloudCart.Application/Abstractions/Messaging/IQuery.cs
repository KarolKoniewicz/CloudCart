using MediatR;
using Ebiscon.CloudCart.Domain.Shared;

namespace Ebiscon.CloudCart.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}
