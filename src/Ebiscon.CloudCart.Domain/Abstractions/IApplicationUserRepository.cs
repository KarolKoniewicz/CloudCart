using Ebiscon.CloudCart.Domain.Entities;

namespace Ebiscon.CloudCart.Domain.Abstractions;

public interface IApplicationUserRepository
{
    Task<ApplicationUser> GetApplicationUserById(string userId, CancellationToken cancellationToken);
}