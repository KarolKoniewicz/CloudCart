using Ebiscon.CloudCart.Domain.Shared;

namespace Ebiscon.CloudCart.Application.Abstractions;

public interface IEmailService
{
    Task<Result> Send();
}