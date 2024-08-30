using Ebiscon.CloudCart.Domain.Shared;

namespace Ebiscon.CloudCart.Application.Abstractions.Services;

public interface IEmailService
{
    Task<Result> Send();
}
