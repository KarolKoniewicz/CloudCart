using MediatR;
using Ebiscon.CloudCart.Domain.Shared;

namespace Ebiscon.CloudCart.Application.Abstractions.Messaging;

public interface ICommand : IRequest<Result>
{
}

public interface ICommand<TResponse> : IRequest<Result<TResponse>>
{
}
