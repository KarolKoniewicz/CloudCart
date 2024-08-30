namespace Ebiscon.CloudCart.Application.Abstractions.Services;

public interface IApplicationUserService
{
    Task<Domain.Entities.ApplicationUser> GetApplicationUserById(string userId, CancellationToken cancellationToken);
}
